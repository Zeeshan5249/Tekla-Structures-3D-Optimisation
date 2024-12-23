﻿<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class HorizontalBeam
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class HorizontalBeam
   ">
    <meta name="generator" content="docfx 2.59.4.0">
    
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
            <article class="content wrap" id="_content" data-uid="TeklaBillboardAid.HorizontalBeam">
  
  
  <h1 id="TeklaBillboardAid_HorizontalBeam" data-uid="TeklaBillboardAid.HorizontalBeam" class="text-break">Class HorizontalBeam
  </h1>
  <div class="markdown level0 summary"><p>A class to create th B1 horizontal beams in the model</p>
</div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">HorizontalBeam</span></div>
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
  <h5 id="TeklaBillboardAid_HorizontalBeam_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public class HorizontalBeam</code></pre>
  </div>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="TeklaBillboardAid_HorizontalBeam_CreateHole_" data-uid="TeklaBillboardAid.HorizontalBeam.CreateHole*"></a>
  <h4 id="TeklaBillboardAid_HorizontalBeam_CreateHole_Tekla_Structures_Model_Beam_Tekla_Structures_Geometry3d_Point_Tekla_Structures_Geometry3d_Point_System_Double_System_Double_TeklaBillboardAid_ModelParameters_" data-uid="TeklaBillboardAid.HorizontalBeam.CreateHole(Tekla.Structures.Model.Beam,Tekla.Structures.Geometry3d.Point,Tekla.Structures.Geometry3d.Point,System.Double,System.Double,TeklaBillboardAid.ModelParameters)">CreateHole(Beam, Point, Point, Double, Double, ModelParameters)</h4>
  <div class="markdown level1 summary"><p>A function to create a hole on a provided beam</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static void CreateHole(Beam BeamToBeBolted, Point HoleFirstPosition, Point HoleSecondPosition, double HoleSize, double CutLength, ModelParameters modelParameters)</code></pre>
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
        <td><span class="xref">Tekla.Structures.Model.Beam</span></td>
        <td><span class="parametername">BeamToBeBolted</span></td>
        <td><p>The beam to have a hole inserted</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">HoleFirstPosition</span></td>
        <td><p>The position of the hole as TSG point</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">HoleSecondPosition</span></td>
        <td><p>A reference point to indicate the perpendicular orientation of the hole</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">HoleSize</span></td>
        <td><p>A double indicating the diameter of the hole</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">CutLength</span></td>
        <td><p>A double indicating the length of the hole</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.ModelParameters.html">ModelParameters</a></td>
        <td><span class="parametername">modelParameters</span></td>
        <td><p>A parameter indicating the parameters of the model</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_HorizontalBeam_HorizontalBeams_" data-uid="TeklaBillboardAid.HorizontalBeam.HorizontalBeams*"></a>
  <h4 id="TeklaBillboardAid_HorizontalBeam_HorizontalBeams_System_Double_System_Double_System_Double_System_Double_Tekla_Structures_Geometry3d_Point_System_Boolean_System_Boolean_System_Double_System_Double_System_Double_System_Collections_Generic_List_System_Double__TeklaBillboardAid_ModelParameters_" data-uid="TeklaBillboardAid.HorizontalBeam.HorizontalBeams(System.Double,System.Double,System.Double,System.Double,Tekla.Structures.Geometry3d.Point,System.Boolean,System.Boolean,System.Double,System.Double,System.Double,System.Collections.Generic.List{System.Double},TeklaBillboardAid.ModelParameters)">HorizontalBeams(Double, Double, Double, Double, Point, Boolean, Boolean, Double, Double, Double, List&lt;Double&gt;, ModelParameters)</h4>
  <div class="markdown level1 summary"><p>The constructor of the class to insert B1 horizontal beams in the model</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static (Beam, Beam, Beam, Beam) HorizontalBeams(double xStart, double xEnd, double boxZStart, double boxZEnd, Point originOffset, bool side1, bool Side3, double B1SplitBeamWidth, double B1SplitBeamDepth, double billboardDepth, List&lt;double&gt; xSubCoordinates, ModelParameters modelParameters)</code></pre>
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
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">xStart</span></td>
        <td><p>A double indicating the start position of the beam</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">xEnd</span></td>
        <td><p>A double indicating the end position og the beam</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">boxZStart</span></td>
        <td><p>A double indicating the starting vertical position of the box frame</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">boxZEnd</span></td>
        <td><p>A double indicating the ending vertical position of the box frame </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">originOffset</span></td>
        <td><p>A TSG point indicating the offset from the origin</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td><span class="parametername">side1</span></td>
        <td><p>A boolean indicating if this side has a split or not (true if it is a split)</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td><span class="parametername">Side3</span></td>
        <td><p>A boolean indicating if this side has a split or not (true if it is a split)</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">B1SplitBeamWidth</span></td>
        <td><p>A double indicating the width of the B1 beams</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">B1SplitBeamDepth</span></td>
        <td><p>A double indicating the depth of the B1 beams</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">billboardDepth</span></td>
        <td><p>A double indicating the billboard depth</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">System.Double</span>&gt;</td>
        <td><span class="parametername">xSubCoordinates</span></td>
        <td><p>A list of doubles which is a subset of x coordinates which a list of LED cabinet widths</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.ModelParameters.html">ModelParameters</a></td>
        <td><span class="parametername">modelParameters</span></td>
        <td><p>A class storing the parameters of the model</p>
</td>
      </tr>
    </tbody>
  </table>
  <h5 class="returns">Returns</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">System.ValueTuple</span>&lt;<span class="xref">Tekla.Structures.Model.Beam</span>, <span class="xref">Tekla.Structures.Model.Beam</span>, <span class="xref">Tekla.Structures.Model.Beam</span>, <span class="xref">Tekla.Structures.Model.Beam</span>&gt;</td>
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
