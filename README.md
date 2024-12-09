Tekla Structures 3D Optimization Phase IV 🚀
Overview
This repository contains the final release and documentation for the Tekla Structures 3D Optimization Project - Phase IV, developed by Jacaranda Flame Consulting - Group 10 for Hanlon Industries. The project focuses on enhancing the Tekla Billboard Aid Plugin to support curved billboard designs while optimizing features for linear billboards.

Features
Curved Billboard Modelling: Automatically generate 3D models for curved billboards.
Flat Billboard Enhancements: Improvements in features such as:
Walkway rails
Curved walers
LED screen panels
Seating plates and Z brackets
Bug Fixes: Enhanced accuracy and reduced rework time by fixing critical bugs from previous phases.
Improved UI: A more intuitive interface for efficient usage.
Repository Structure
plaintext
Copy code
├── Final Release/                     # Contains the executable and source code for the final version
├── Documentation/                     # All documentation related to the project
│   ├── Final Report - Phase IV.pdf    # Detailed project report
│   ├── Technical Documentation.pdf    # Developer guide for code structure
│   ├── User Documentation.pdf         # End-user instructions
│   ├── Project Charter.pdf            # Project scope and goals
│   └── Presentation Slides.pptx       # Summary presentation
└── README.md                          # Project overview and usage guide
Getting Started
Follow the steps below to set up and run the software.

Prerequisites
Tekla Structures:
Ensure you have Tekla Structures installed (2023 or later recommended).
Install Tekla OpenAPI (version compatible with your Tekla installation).
Visual Studio:
Install Visual Studio for building and modifying the source code.
.NET Framework:
Ensure the required .NET Framework version is installed.
Installation
Clone the repository:
bash
Copy code
git clone https://github.com/<your-username>/<repo-name>.git
Navigate to the Final Release folder.
Open the project in Visual Studio and build the solution.
Run the executable or modify the code as needed.
Usage
Open the application after ensuring Tekla Structures is running.
Input the desired parameters for your billboard (e.g., rows, columns, radius, etc.).
Click Validate to ensure the inputs are compatible.
Generate the model by clicking Build. The BIM model will be outputted in Tekla Structures.
For detailed instructions, refer to:

User Documentation
Documentation
Final Report: Comprehensive project details.
Technical Documentation: Code structure and developer guidance.
User Documentation: How to use the application.
Project Charter: Goals and scope.
Presentation Slides: Summary presentation.
Future Work
Refactor the codebase for optimization and modularity.
Extend functionality to handle more complex curved billboard designs.
Enhance the UI further for better user experience.
