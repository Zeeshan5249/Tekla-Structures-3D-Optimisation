﻿<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class Plate
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class Plate
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
            <article class="content wrap" id="_content" data-uid="TeklaBillboardAid.Plate">
  
  
  <h1 id="TeklaBillboardAid_Plate" data-uid="TeklaBillboardAid.Plate" class="text-break">Class Plate
  </h1>
  <div class="markdown level0 summary"><p>Class to support modeling of plates on Tekla Structures. </p>
</div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">Plate</span></div>
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
  <h5 id="TeklaBillboardAid_Plate_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public class Plate</code></pre>
  </div>
  <h3 id="constructors">Constructors
  </h3>
  
  
  <a id="TeklaBillboardAid_Plate__ctor_" data-uid="TeklaBillboardAid.Plate.#ctor*"></a>
  <h4 id="TeklaBillboardAid_Plate__ctor_System_Collections_Generic_List_Tekla_Structures_Geometry3d_Point__System_String_System_String_Tekla_Structures_Model_Position_DepthEnum_System_String_System_String_System_String_System_String_System_String_" data-uid="TeklaBillboardAid.Plate.#ctor(System.Collections.Generic.List{Tekla.Structures.Geometry3d.Point},System.String,System.String,Tekla.Structures.Model.Position.DepthEnum,System.String,System.String,System.String,System.String,System.String)">Plate(List&lt;Point&gt;, String, String, Position.DepthEnum, String, String, String, String, String)</h4>
  <div class="markdown level1 summary"><p>Constructor to create a plate.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Plate(List&lt;Point&gt; points, string profile, string material, Position.DepthEnum depth = Position.DepthEnum.MIDDLE, string plateClass = &quot;1&quot;, string plateName = &quot;&quot;, string plateFinish = &quot;&quot;, string partprefix = &quot;PL&quot;, string assprefix = &quot;&quot;)</code></pre>
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
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">Tekla.Structures.Geometry3d.Point</span>&gt;</td>
        <td><span class="parametername">points</span></td>
        <td><p>List of 3D coordinates in the cross section. Points must be provided in clockwise/counter-clockwise order. </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">profile</span></td>
        <td><p>Profile of the plate. </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">material</span></td>
        <td><p>Material of the plate.</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Model.Position.DepthEnum</span></td>
        <td><span class="parametername">depth</span></td>
        <td><p>Depth enumeration to position the plate. </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">plateClass</span></td>
        <td><p>Changes colour of part. </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">plateName</span></td>
        <td><p>Name field of plate. </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">plateFinish</span></td>
        <td><p>Finish field of plate. </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">partprefix</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">assprefix</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Plate__ctor_" data-uid="TeklaBillboardAid.Plate.#ctor*"></a>
  <h4 id="TeklaBillboardAid_Plate__ctor_Tekla_Structures_Geometry3d_Point_System_String_System_String_Tekla_Structures_Model_Position_DepthEnum_System_Double_System_Double_System_Double_System_String_System_String_System_String_" data-uid="TeklaBillboardAid.Plate.#ctor(Tekla.Structures.Geometry3d.Point,System.String,System.String,Tekla.Structures.Model.Position.DepthEnum,System.Double,System.Double,System.Double,System.String,System.String,System.String)">Plate(Point, String, String, Position.DepthEnum, Double, Double, Double, String, String, String)</h4>
  <div class="markdown level1 summary"><p>Overloaded constructor to create a rectangular plate in the XY, XZ or YZ plane using a centre point and x/y/z dimensions. Exactly two of xOffset, yOffset and zOffset must be set.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Plate(Point centre, string profile, string material, Position.DepthEnum depth = Position.DepthEnum.BEHIND, double xOffset = 0, double yOffset = 0, double zOffset = 0, string plateClass = &quot;1&quot;, string plateName = &quot;&quot;, string plateFinish = &quot;&quot;)</code></pre>
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
        <td><span class="parametername">centre</span></td>
        <td><p>3D coordinates of the plate&apos;s centre (mm) </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">profile</span></td>
        <td><p>Profile of the plate. </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">material</span></td>
        <td><p>Material of the plate.</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Model.Position.DepthEnum</span></td>
        <td><span class="parametername">depth</span></td>
        <td><p>Depth enumeration to position the plate. </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">xOffset</span></td>
        <td><p>Offset of corners in the x direction from the centre (mm)</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">yOffset</span></td>
        <td><p>Offset of corners in the y direction from the centre (mm)</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">zOffset</span></td>
        <td><p>Offset of corners in the z direction from the centre (mm)</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">plateClass</span></td>
        <td><p>Changes colour of part. </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">plateName</span></td>
        <td><p>Name field of plate. </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">plateFinish</span></td>
        <td><p>Finish field of plate. </p>
</td>
      </tr>
    </tbody>
  </table>
  <h3 id="properties">Properties
  </h3>
  
  
  <a id="TeklaBillboardAid_Plate_ContourPlate_" data-uid="TeklaBillboardAid.Plate.ContourPlate*"></a>
  <h4 id="TeklaBillboardAid_Plate_ContourPlate" data-uid="TeklaBillboardAid.Plate.ContourPlate">ContourPlate</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public ContourPlate ContourPlate { get; set; }</code></pre>
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
        <td><p>Object storing the modeled plate to interact with Tekla Open API</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Plate_Material_" data-uid="TeklaBillboardAid.Plate.Material*"></a>
  <h4 id="TeklaBillboardAid_Plate_Material" data-uid="TeklaBillboardAid.Plate.Material">Material</h4>
  <div class="markdown level1 summary"><p>The material of the plate</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public string Material { get; set; }</code></pre>
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
        <td><span class="xref">System.String</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Plate_Points_" data-uid="TeklaBillboardAid.Plate.Points*"></a>
  <h4 id="TeklaBillboardAid_Plate_Points" data-uid="TeklaBillboardAid.Plate.Points">Points</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public List&lt;Point&gt; Points { get; set; }</code></pre>
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
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">Tekla.Structures.Geometry3d.Point</span>&gt;</td>
        <td><p>Points used to form the plate (mm)</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Plate_Profile_" data-uid="TeklaBillboardAid.Plate.Profile*"></a>
  <h4 id="TeklaBillboardAid_Plate_Profile" data-uid="TeklaBillboardAid.Plate.Profile">Profile</h4>
  <div class="markdown level1 summary"><p>The profile of the plate</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public string Profile { get; set; }</code></pre>
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
        <td><span class="xref">System.String</span></td>
        <td></td>
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
