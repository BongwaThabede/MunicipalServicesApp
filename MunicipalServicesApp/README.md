# Municipal Services Application — README

## About
A C# .NET Framework (4.8) Windows Forms application for reporting and
tracking municipal service requests. It now supports two kinds of user:

- **Residents** — register an account, log in, report issues, and track
  the status and feedback on everything they've reported.
- **Municipal staff** — log in separately, see every request submitted by
  every resident, and update a request's status while leaving a feedback
  message that the resident sees on their own tracking screen.

"Local Events and Announcements" is still visible on the resident menu but
disabled, as required — it's a future part of the PoE.

**User engagement strategy implemented:** real-time status tracking and
progress feedback, carried all the way through the app rather than just
on the reporting form:
- A **live progress bar, colour state, green checkmarks, and encouraging
  messages** while filling in a report (details below).
- A dedicated **"Track My Service Requests"** screen where residents see
  every request they've made, its current status, and a full timeline of
  status changes and feedback messages from the municipality.
- A **municipal dashboard** where staff can change a request's status and
  leave feedback, which flows straight back to the resident.

## Roles and demo login
| Role | How to get an account | Demo credentials |
|---|---|---|
| Resident | Click **Register** on the login screen | (create your own) |
| Municipal staff | Pre-provisioned — staff accounts aren't self-registered | username `municipality`, password `Municipal@123` |

Logging in with the resident account you register opens the **Main Menu**
(Report Issues / Track My Service Requests). Logging in with the municipal
account opens the **Municipal Dashboard** instead.

## Status stages
Every reported issue moves through these stages, in order:
`Submitted → Under Review → In Progress → Resolved → Closed`

A request is automatically stamped **Submitted** the moment a resident
reports it. Municipal staff can move it to any other stage and attach an
optional feedback message each time — every change is kept in the
request's history, not just the latest one.

## Project structure
```
MunicipalServicesApp.sln
MunicipalServicesApp/
├── MunicipalServicesApp.csproj
├── App.config
├── Program.cs                              # entry point — opens LoginForm
├── UserSession.cs                          # holds the logged-in account
├── LoginForm.cs / .Designer.cs             # sign in (resident or staff)
├── RegisterForm.cs / .Designer.cs          # resident self-registration
├── MainMenuForm.cs / .Designer.cs          # resident hub
├── ReportIssuesForm.cs / .Designer.cs      # report an issue
├── ServiceRequestStatusForm.cs / .Designer.cs   # resident: track my requests
├── MunicipalDashboardForm.cs / .Designer.cs     # staff: manage all requests
├── Models/
│   ├── UserAccount.cs                      # resident/staff account
│   ├── ServiceRequest.cs                   # a reported issue
│   ├── RequestStatus.cs                    # the five status stages
│   └── StatusUpdate.cs                     # one timeline entry
└── Data/
    ├── UserRepository.cs                   # accounts (salted-hash passwords)
    └── IssueRepository.cs                  # all reported issues
```

## How to compile and run

### Option A — Visual Studio (recommended)
1. Install **Visual Studio 2022** (Community edition is free) with the
   ".NET desktop development" workload, which includes .NET Framework 4.8
   and the Windows Forms designer.
2. Open `MunicipalServicesApp.sln`.
3. Press **F5** (or **Ctrl+F5** to run without debugging).

### Option B — Command line (MSBuild), Windows only
1. From a "Developer Command Prompt for VS", navigate to the solution
   folder and run:
   ```
   msbuild MunicipalServicesApp.sln /p:Configuration=Release
   ```
2. Run the built executable:
   ```
   MunicipalServicesApp\bin\Release\MunicipalServicesApp.exe
   ```

> This is a Windows Forms (.NET Framework) desktop application and
> requires Windows to run. It was syntax-verified during development with
> the Mono C# compiler (zero errors), but should be built/run with Visual
> Studio and .NET Framework 4.8 for the intended experience.

## How to use it — as a resident
1. On the login screen, click **Register**, fill in a full name, username
   and password (minimum 6 characters), and submit.
2. Log in with the account you just created.
3. From the **Main Menu**, click **Report Issues** and fill in Location,
   Category and Description (all required — watch the progress bar, the
   checkmarks, and the character counter update live). Attach a photo or
   document if you like, then **Submit Report**. You'll get a reference
   number.
4. Click **Back to Main Menu**, then **Track My Service Requests** to see
   every issue you've reported. Select one to see its full status history
   — including any feedback left by municipal staff. Click **Refresh** to
   pull the latest status.
5. **Logout** returns you to the login screen.

## How to use it — as municipal staff
1. Log in with the demo staff account above (`municipality` /
   `Municipal@123`).
2. The **Municipal Dashboard** lists every request from every resident.
   Select one to see its description, attachments, and full history.
3. Choose a new status from the dropdown, optionally type a feedback
   message, and click **Update Status**. The resident will see this the
   next time they open "Track My Service Requests".
4. **Logout** returns you to the login screen.

## Data storage and security
- Accounts and service requests are held in memory (`List<UserAccount>`
  and `List<ServiceRequest>`) for the lifetime of the running application,
  via `UserRepository` and `IssueRepository`. This keeps the focus on the
  application logic required by the brief; swapping in a database or a
  file/JSON store later only means changing these two repository classes,
  since every form talks to them through the same methods.
- Passwords are **never stored in plain text**. Each account gets a random
  salt (`RNGCryptoServiceProvider`), and only a salted SHA-256 hash of the
  password is kept.
- Because storage is in-memory, registered accounts and reported issues
  reset each time the application restarts (aside from the seeded
  `municipality` demo account, which is recreated automatically). This is
  intentional for a coursework demo — it means a marker can register a
  fresh resident, log in as staff, and see the whole loop work end to end
  without any leftover data from a previous run.
