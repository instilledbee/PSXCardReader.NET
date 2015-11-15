# PSXCardReader.NET
A .NET Windows Forms Playstation (PSX) memory card reader application

# About
This project serves as a rudimentary front-end for the [PSXMMCLibrary](http://github.com/instilledbee/psxmmclibrary) project, and as a primary example on how to consume the library's available API. As with the PSXMMCLibrary, it is as of date not considered feature-complete, and the repository has been made public with the intent of letting others use and improve the project.

# Project Structure
The project has been designed with the [model-view-presenter](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93presenter) architectural pattern in mind, specifically a passive-view archetype. it is recommended to keep in mind the purpose of each module when implementing modifications, for good coding practices and maintaing separation of concerns.

* `PSXCardReader.NET.Presenter` contains the presenter classes, interfaces and majority of the logic. This is where you want to look to know how the project uses the PSXMMCLibrary.
* `PSXCardReader.NET.View` contains view interfaces implemented by the WinForms project.
* `PSXCardReader.NET` is an implementation of the View interfaces, represented by a WinForms GUI application.

The models used by this MVP application come from the `PSXMMCLibrary.Models` namespace.

# Current Features
* Usage of the PSXMMCLibrary API.
* Designed with MVP pattern in mind, for separation of concerns and decoupling of implementations.
* Can open ePSXe (*.mcr) file formats, with basic file validation on opening.

# Planned Features
* Display more memory card details (icon image, raw save data, directory frame data)
* Unit tests for presenter
* Implement the planned/new features of the PSXMMCLibrary project, as it is updated.


