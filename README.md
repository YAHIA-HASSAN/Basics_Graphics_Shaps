# Basics_Graphics_Shaps

Basics_Graphics_Shaps is a Windows Forms application that allows users to draw basic geometric shapes: lines, circles, and ellipses. The application utilizes various algorithms to render these shapes and serves as a simple example of graphic programming in .NET.

## Features

- **Draw Line**: Implements Bresenham's and DDA line algorithms.
- **Draw Circle**: Uses different circle drawing algorithms including the Midpoint algorithm.
- **Draw Ellipse**: Provides functionality for ellipse drawing with different algorithms.

## Project Structure

- **`AbstractLine.cs`**: Base class for line drawing algorithms.
- **`Bres_Line.cs`**: Implements Bresenham's line drawing algorithm.
- **`DDA_Line.cs`**: Implements the Digital Differential Analyzer line drawing algorithm.
- **`Circle.Designer.cs`, `Circle.cs`, `Circle.resx`**: Files related to circle drawing functionalities.
- **`CircleDraw.cs`**: Contains methods for drawing circles.
- **`EllipsDraw.cs`, `Ellipse.Designer.cs`, `Ellipse.cs`, `Ellipse.resx`, `Ellipse_Midpoint.cs`**: Files related to ellipse drawing functionalities, including the Midpoint algorithm.
- **`LineBres.Designer.cs`, `LineBres.cs`, `LineBres.resx`**: Files specific to Bresenham's line algorithm.
- **`LineDDA.Designer.cs`, `LineDDA.cs`, `LineDDA.resx`**: Files specific to the DDA line algorithm.
- **`Line_Clipping.cs`**: Implements line clipping algorithms.
- **`Program.cs`**: Entry point of the application.
- **`Home.Designer.cs`, `Home.cs`, `Home.resx`**: Main form files for the application.
- **`Welcom.Designer.cs`, `Welcom.cs`, `Welcom.resx`**: Welcome form files.
- **`mid_point.cs`**: Contains midpoint algorithm implementations.

## Prerequisites

- **.NET Framework**: Ensure that the .NET Framework 4.7.2 or later is installed.

## Installation

1. **Clone the Repository**: 
   ```bash
   git clone https://github.com/yourusername/Basics_Graphics_Shaps.git
