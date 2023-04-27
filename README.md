# MementoMori
This is a Winform C# program called "Memento Mori" that serves as a Dead Man Switch for your privacy. 
Upon running the user will be asked for a password, and if the user fails to submit the password within 20s, it will delete a list of folders provided by the user.
This can be useful for maintaining privacy and security in the event that the user is unable to manually delete sensitive information.

- currently checks %USERPROFILE%\mementomori.txt for the password
- list of files to delete can be found in %USERPROFILE%\mementolist.txt, separated by linebreaks

## Why?

- Privacy.

## Features
- Simple and intuitive user interface for entering the password.
- Customizable list of folders to delete.
- Provides visual and audible feedback to indicate whether the user has successfully submitted the password or if the time limit has expired.
- Can be configured to run on startup.

## Getting Started

### Prerequisites
- Windows operating system
- .NET Framework 7 or higher

### Installation
- Build in Visual Studio.

## Usage
- Launch the program by double-clicking the MementoMori.exe file, or by having it run on login (preferred).
- Enter the password in the password field and click the "Unlock" button.
- If the password is submitted successfully within the specified time limit, the program will quietly exit.
- If the password is not submitted within the time limit, the program will delete the folders specified in the .mementolist.txt file and display a cryptic message.
- To customize the list of folders to delete, edit the mementolist.txt file in the program directory using a text editor. Each folder path should be on a separate line.
- To configure the unlock code, change it in mementomori.txt

## License
This program is released under the MIT License.