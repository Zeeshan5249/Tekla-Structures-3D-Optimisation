﻿<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class Frame
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class Frame
   ">
    <meta name="generator" content="docfx 2.59.3.0">
    
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" href="../styles/docfx.vendor.css">
    <link rel="stylesheet" href="../styles/docfx.css">
    <link rel="stylesheet" href="../styles/main.css">
    <meta property="docfx:navrel" content="../toc.html">
    <meta property="docfx:tocrel" content="toc.html">
    
    
    
  </head>
  <body data-spy="scroll" data-target="#affix" data-offset="120">
    <div id="wrapper">
      <header>
        
        <nav id="autocollapse" class="navbar navbar-inverse ng-scope" role="navigation">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              
              <a class="navbar-brand" href="../index.html">
                <img id="logo" class="svg" src="../logo.svg" alt="">
              </a>
            </div>
            <div class="collapse navbar-collapse" id="navbar">
              <form class="navbar-form navbar-right" role="search" id="search">
                <div class="form-group">
                  <input type="text" class="form-control" id="search-query" placeholder="Search" autocomplete="off">
                </div>
              </form>
            </div>
          </div>
        </nav>
        
        <div class="subnav navbar navbar-default">
          <div class="container hide-when-search" id="breadcrumb">
            <ul class="breadcrumb">
              <li></li>
            </ul>
          </div>
        </div>
      </header>
      <div role="main" class="container body-content hide-when-search">
        
        <div class="sidenav hide-when-search">
          <a class="btn toc-toggle collapse" data-toggle="collapse" href="#sidetoggle" aria-expanded="false" aria-controls="sidetoggle">Show / Hide Table of Contents</a>
          <div class="sidetoggle collapse" id="sidetoggle">
            <div id="sidetoc"></div>
          </div>
        </div>
        <div class="article row grid-right">
          <div class="col-md-10">
            <article class="content wrap" id="_content" data-uid="TeklaBillboardAid.Frame">
  
  
  <h1 id="TeklaBillboardAid_Frame" data-uid="TeklaBillboardAid.Frame" class="text-break">Class Frame
  </h1>
  <div class="markdown level0 summary"><p>Class to support modeling of the major structural components of the billboard frame in Tekla Structures.</p>
</div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">Frame</span></div>
  </div>
  <div class="inheritedMembers">
    <h5>Inherited Members</h5>
    <div>
      <span class="xref">System.Object.ToString()</span>
    </div>
    <div>
      <span class="xref">System.Object.Equals(System.Object)</span>
    </div>
    <div>
      <span class="xref">System.Object.Equals(System.Object, System.Object)</span>
    </div>
    <div>
      <span class="xref">System.Object.ReferenceEquals(System.Object, System.Object)</span>
    </div>
    <div>
      <span class="xref">System.Object.GetHashCode()</span>
    </div>
    <div>
      <span class="xref">System.Object.GetType()</span>
    </div>
    <div>
      <span class="xref">System.Object.MemberwiseClone()</span>
    </div>
  </div>
  <h6><strong>Namespace</strong>: <a class="xref" href="TeklaBillboardAid.html">TeklaBillboardAid</a></h6>
  <h6><strong>Assembly</strong>: BeamApplication.dll</h6>
  <h5 id="TeklaBillboardAid_Frame_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public class Frame</code></pre>
  </div>
  <h3 id="constructors">Constructors
  </h3>
  
  
  <a id="TeklaBillboardAid_Frame__ctor_" data-uid="TeklaBillboardAid.Frame.#ctor*"></a>
  <h4 id="TeklaBillboardAid_Frame__ctor_Tekla_Structures_Geometry3d_Point_Tekla_Structures_Geometry3d_Point_Tekla_Structures_Geometry3d_Point_Tekla_Structures_Geometry3d_Point_System_Int32_TeklaBillboardAid_ModelParameters_" data-uid="TeklaBillboardAid.Frame.#ctor(Tekla.Structures.Geometry3d.Point,Tekla.Structures.Geometry3d.Point,Tekla.Structures.Geometry3d.Point,Tekla.Structures.Geometry3d.Point,System.Int32,TeklaBillboardAid.ModelParameters)">Frame(Point, Point, Point, Point, Int32, ModelParameters)</h4>
  <div class="markdown level1 summary"><p>Constructor to generate a frame model.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Frame(Point point1, Point point2, Point point3, Point point4, int planeType, ModelParameters modelParameters)</code></pre>
  </div>
  <h5 class="parameters">Parameters</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Name</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">point1</span></td>
        <td><p>The point coordinate for the bottom-right corner of the plate (mm)</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">point2</span></td>
        <td><p>The point coordinate for the bottom-right corner of the plate (mm)</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">point3</span></td>
        <td><p>The point coordinate for the bottom-right corner of the plate (mm)</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">point4</span></td>
        <td><p>The point coordinate for the bottom-right corner of the plate (mm)</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Int32</span></td>
        <td><span class="parametername">planeType</span></td>
        <td><p>Integer representation for the plane position:
0 = first plane
1 = last plane
2 = planes in between the first and last planes </p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.ModelParameters.html">ModelParameters</a></td>
        <td><span class="parametername">modelParameters</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="properties">Properties
  </h3>
  
  
  <a id="TeklaBillboardAid_Frame_Back_" data-uid="TeklaBillboardAid.Frame.Back*"></a>
  <h4 id="TeklaBillboardAid_Frame_Back" data-uid="TeklaBillboardAid.Frame.Back">Back</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Beam Back { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">Tekla.Structures.Model.Beam</span></td>
        <td><p>The back beam between points 2 and 3</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Frame_Bottom_" data-uid="TeklaBillboardAid.Frame.Bottom*"></a>
  <h4 id="TeklaBillboardAid_Frame_Bottom" data-uid="TeklaBillboardAid.Frame.Bottom">Bottom</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Beam Bottom { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">Tekla.Structures.Model.Beam</span></td>
        <td><p>The bottom beam between points 1 and 2</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Frame_Front_" data-uid="TeklaBillboardAid.Frame.Front*"></a>
  <h4 id="TeklaBillboardAid_Frame_Front" data-uid="TeklaBillboardAid.Frame.Front">Front</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Beam Front { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">Tekla.Structures.Model.Beam</span></td>
        <td><p>The front beam between points 1 and 4</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Frame_IfWalkway_" data-uid="TeklaBillboardAid.Frame.IfWalkway*"></a>
  <h4 id="TeklaBillboardAid_Frame_IfWalkway" data-uid="TeklaBillboardAid.Frame.IfWalkway">IfWalkway</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public bool IfWalkway { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Frame_ModelParameters_" data-uid="TeklaBillboardAid.Frame.ModelParameters*"></a>
  <h4 id="TeklaBillboardAid_Frame_ModelParameters" data-uid="TeklaBillboardAid.Frame.ModelParameters">ModelParameters</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public ModelParameters ModelParameters { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.ModelParameters.html">ModelParameters</a></td>
        <td><p>The model parameters data store</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Frame_PlaneType_" data-uid="TeklaBillboardAid.Frame.PlaneType*"></a>
  <h4 id="TeklaBillboardAid_Frame_PlaneType" data-uid="TeklaBillboardAid.Frame.PlaneType">PlaneType</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public int PlaneType { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.Int32</span></td>
        <td><p>Integer representation for the plane position: 0 = first plane, 1 = last plane, 2 = planes in between the first and last planes</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Frame_Point1_" data-uid="TeklaBillboardAid.Frame.Point1*"></a>
  <h4 id="TeklaBillboardAid_Frame_Point1" data-uid="TeklaBillboardAid.Frame.Point1">Point1</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Point Point1 { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><p>The point coordinate for the bottom-right corner of the plate (mm)</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Frame_Point2_" data-uid="TeklaBillboardAid.Frame.Point2*"></a>
  <h4 id="TeklaBillboardAid_Frame_Point2" data-uid="TeklaBillboardAid.Frame.Point2">Point2</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Point Point2 { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><p>The point coordinate for the bottom-left corner of the plate (mm)</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Frame_Point3_" data-uid="TeklaBillboardAid.Frame.Point3*"></a>
  <h4 id="TeklaBillboardAid_Frame_Point3" data-uid="TeklaBillboardAid.Frame.Point3">Point3</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Point Point3 { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><p>The point coordinate for the top-left corner of the plate (mm)</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Frame_Point4_" data-uid="TeklaBillboardAid.Frame.Point4*"></a>
  <h4 id="TeklaBillboardAid_Frame_Point4" data-uid="TeklaBillboardAid.Frame.Point4">Point4</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Point Point4 { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><p>The point coordinate for the top-right corner of the plate (mm)</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Frame_Seatplate_" data-uid="TeklaBillboardAid.Frame.Seatplate*"></a>
  <h4 id="TeklaBillboardAid_Frame_Seatplate" data-uid="TeklaBillboardAid.Frame.Seatplate">Seatplate</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public ContourPlate Seatplate { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">Tekla.Structures.Model.ContourPlate</span></td>
        <td><p>The seating plate below the LED cabinets</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Frame_Top_" data-uid="TeklaBillboardAid.Frame.Top*"></a>
  <h4 id="TeklaBillboardAid_Frame_Top" data-uid="TeklaBillboardAid.Frame.Top">Top</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Beam Top { get; set; }</code></pre>
  </div>
  <h5 class="propertyValue">Property Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">Tekla.Structures.Model.Beam</span></td>
        <td><p>The top beam between points 3 and 4</p>
</td>
      </tr>
    </tbody>
  </table>
</article>
          </div>
          
          <div class="hidden-sm col-md-2" role="complementary">
            <div class="sideaffix">
              <div class="contribution">
                <ul class="nav">
                </ul>
              </div>
              <nav class="bs-docs-sidebar hidden-print hidden-xs hidden-sm affix" id="affix">
                <h5>In This Article</h5>
                <div></div>
              </nav>
            </div>
          </div>
        </div>
      </div>
      
      <footer>
        <div class="grad-bottom"></div>
        <div class="footer">
          <div class="container">
            <span class="pull-right">
              <a href="#top">Back to top</a>
            </span>
            
            <span>Generated by <strong>DocFX</strong></span>
          </div>
        </div>
      </footer>
    </div>
    
    <script type="text/javascript" src="../styles/docfx.vendor.js"></script>
    <script type="text/javascript" src="../styles/docfx.js"></script>
    <script type="text/javascript" src="../styles/main.js"></script>
  </body>
</html>