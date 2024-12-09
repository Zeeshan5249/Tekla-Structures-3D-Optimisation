# Tekla Structures 3D Optimization Phase IV 🚀

## Overview
This repository contains the final release and documentation for the **Tekla Structures 3D Optimization Project - Phase IV**, developed by **Jacaranda Flame Consulting - Group 10** for **Hanlon Industries**. The project enhances the Tekla Billboard Aid Plugin to support curved billboard designs, as well as refining features for linear billboards.

## Features
- **Curved Billboard Modelling:** Automatically generate 3D models for curved billboards.
- **Flat Billboard Enhancements:**
  - Walkway rails
  - Curved walers
  - LED screen panels
  - Seating plates and Z brackets
- **Bug Fixes:** Enhanced accuracy and reduced rework time by resolving critical issues from previous phases.
- **Improved UI:** A more intuitive interface for efficient and user-friendly operations.

## Repository Structure
<pre>
├── Final Release/                     # Contains the executable and source code for the final version
├── Documentation/                     # All documentation related to the project
│   ├── Final Report - Phase IV.pdf    # Detailed project report
│   ├── Technical Documentation.pdf    # Developer guide for code structure
│   ├── User Documentation.pdf         # End-user instructions
│   ├── Project Charter.pdf            # Project scope and goals
│   └── Presentation Slides.pptx       # Summary presentation
└── README.md                          # Project overview and usage guide
</pre>

## Getting Started

### Prerequisites
- **Tekla Structures:**
  - Tekla Structures 2023 or later recommended.
  - Tekla OpenAPI (compatible version with your Tekla installation).
- **Visual Studio:** Required for building and modifying the source code.
- **.NET Framework:** Ensure the required .NET Framework version is installed.

### Installation
1. **Clone the repository:**
   <pre>
   git clone https://github.com/<your-username>/<repo-name>.git 
   </pre>
2. **Navigate to the `Final Release` folder.**   
3. **Open the project in Visual Studio and build the solution.**  
4. **Run the executable or modify the code as needed.**

### Usage
1. **Launch Tekla Structures** and ensure it is running.
2. **Open the application** from the Final Release folder.
3. **Input your parameters** (e.g., rows, columns, radius for curved billboards, etc.).
4. **Click `Validate`** to check the compatibility of the inputs.
5. **Click `Build`** to generate the BIM model within Tekla Structures.

For detailed step-by-step instructions and tips, refer to:  
- **[User Documentation](./Documentation/User%20Documentation.pdf)**

## Documentation
- **[Final Report - Phase IV](./Documentation/Final%20Report%20-%20Phase%20IV.pdf):** Comprehensive project details.
- **[Technical Documentation](./Documentation/Technical%20Documentation.pdf):** In-depth developer guidance on code structure.
- **[User Documentation](./Documentation/User%20Documentation.pdf):** Instructions for end-users.
- **[Project Charter](./Documentation/Project%20Charter.pdf):** Project goals, scope, and objectives.
- **[Presentation Slides](./Documentation/Presentation%20Slides.pptx):** Summary presentation of the project.

## Future Work
- **Code Refactoring:** Improve modularity, maintainability, and performance.
- **Extended Functionality:** Support more complex curved billboard designs and additional features.
- **UI Enhancements:** Further refine the user interface for an even better experience.
