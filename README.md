# DogWatch
This is a repository for files written by team Nevermore for [MATHackathon](http://mathack.rs) 2017. The competition lasted 6 hours and the theme was "Smart home component". The team won second prize.

Authors: [KockaAdmiralac](https://github.com/KockaAdmiralac) and [lazar2222](https://github.com/lazar2222)

**Note:** This application won't work without slight modifications. It was written for a hackathon, and Twillio token has been stripped. Don't expect proper documentation in future.

## Idea
A smart home component the team was making was a smart dog bowl that uses Arduino with a motion sensor and four wires as a water level sensor to detect the amount of water left in the dog bowl and if the dog is currently drinking the water, send that information to a C# application which records it in a file and notifies a user through SMS (using Twillio API) if the bowl is empty. It also contains a webserver that reads the file with current status and shows information about the bowl and drinking status. It also contains an Android application that queries the webserver's JSON endpoint about the bowl and drinking status and displays it.

## Components
- `app` - Android app for displaying bowl status
- `hardware` - Arduino program for handling sensors
- `img` - Images used in presentation
- `reader` - C# application to read and record hardware state and notify the user through SMS
- `website` - Web application for displaying bowl status

Programming languages used:
- Java
- C (Arduino)
- C#
- PHP
- JavaScript