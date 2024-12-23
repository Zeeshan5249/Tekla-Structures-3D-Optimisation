<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class LiftPoint
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class LiftPoint
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
            <article class="content wrap" id="_content" data-uid="TeklaBillboardAid.LiftPoint">
  
  
  <h1 id="TeklaBillboardAid_LiftPoint" data-uid="TeklaBillboardAid.LiftPoint" class="text-break">Class LiftPoint
  </h1>
  <div class="markdown level0 summary"><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Class to support modeling of lifting points for billboard frames in Tekla Structures.</p>
</div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">LiftPoint</span></div>
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
  <h5 id="TeklaBillboardAid_LiftPoint_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public class LiftPoint</code></pre>
  </div>
  <h3 id="constructors">Constructors
  </h3>
  
  
  <a id="TeklaBillboardAid_LiftPoint__ctor_" data-uid="TeklaBillboardAid.LiftPoint.#ctor*"></a>
  <h4 id="TeklaBillboardAid_LiftPoint__ctor_Tekla_Structures_Model_Beam_Tekla_Structures_Geometry3d_Point_System_Boolean_TeklaBillboardAid_ModelParameters_" data-uid="TeklaBillboardAid.LiftPoint.#ctor(Tekla.Structures.Model.Beam,Tekla.Structures.Geometry3d.Point,System.Boolean,TeklaBillboardAid.ModelParameters)">LiftPoint(Beam, Point, Boolean, ModelParameters)</h4>
  <div class="markdown level1 summary"><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Constructor for a single lifting point.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public LiftPoint(Beam beam, Point position, bool isTop, ModelParameters modelParameters)</code></pre>
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
        <td><span class="parametername">beam</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="1" sourceendlinenumber="1">B1 member to insert the lifting point on </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">position</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="1" sourceendlinenumber="1">3D coordinates of the point to insert the lifting point </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td><span class="parametername">isTop</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="1" sourceendlinenumber="1">True if beam refers to the top B1 member, False otherwise </p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.ModelParameters.html">ModelParameters</a></td>
        <td><span class="parametername">modelParameters</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="fields">Fields
  </h3>
  
  
  <h4 id="TeklaBillboardAid_LiftPoint_EyeBolt" data-uid="TeklaBillboardAid.LiftPoint.EyeBolt">EyeBolt</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public BoltArray EyeBolt</code></pre>
  </div>
  <h5 class="fieldValue">Field Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><span class="xref">Tekla.Structures.Model.BoltArray</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Modeled as a 24 mm standard bolt. Placeholder only.</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <h4 id="TeklaBillboardAid_LiftPoint_IsTop" data-uid="TeklaBillboardAid.LiftPoint.IsTop">IsTop</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public bool IsTop</code></pre>
  </div>
  <h5 class="fieldValue">Field Value</h5>
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
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Whether the lifting point is on the top or bottom B1 member.</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <h4 id="TeklaBillboardAid_LiftPoint_Plate" data-uid="TeklaBillboardAid.LiftPoint.Plate">Plate</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Plate Plate</code></pre>
  </div>
  <h5 class="fieldValue">Field Value</h5>
  <table class="table table-bordered table-striped table-condensed">
    <thead>
      <tr>
        <th>Type</th>
        <th>Description</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.Plate.html">Plate</a></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Modeled as a 75 x 75 x 10 mm plate as per the engineering drawing.</p>
</td>
      </tr>
    </tbody>
  </table>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="TeklaBillboardAid_LiftPoint_FindLiftPoints_" data-uid="TeklaBillboardAid.LiftPoint.FindLiftPoints*"></a>
  <h4 id="TeklaBillboardAid_LiftPoint_FindLiftPoints_System_Collections_Generic_List_System_Double__System_Double_System_Double_" data-uid="TeklaBillboardAid.LiftPoint.FindLiftPoints(System.Collections.Generic.List{System.Double},System.Double,System.Double)">FindLiftPoints(List&lt;Double&gt;, Double, Double)</h4>
  <div class="markdown level1 summary"><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Determines where to insert the lifting points. Points are assumed to share the same (y,z) coordinate as its parent beam.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static Point[] FindLiftPoints(List&lt;double&gt; xCoords, double y, double z)</code></pre>
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
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">System.Double</span>&gt;</td>
        <td><span class="parametername">xCoords</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="1" sourceendlinenumber="1">list of x coordinates to insert the lifting points at </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">y</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="1" sourceendlinenumber="1">y coordinate of the parent beam </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">z</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="1" sourceendlinenumber="1">z coordinate of the parent beam </p>
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
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span>[]</td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Array of points to insert the lifting points. </p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_LiftPoint_ValidateLiftPoint_" data-uid="TeklaBillboardAid.LiftPoint.ValidateLiftPoint*"></a>
  <h4 id="TeklaBillboardAid_LiftPoint_ValidateLiftPoint_System_Double_TeklaBillboardAid_ModelParameters_System_Boolean_" data-uid="TeklaBillboardAid.LiftPoint.ValidateLiftPoint(System.Double,TeklaBillboardAid.ModelParameters,System.Boolean)">ValidateLiftPoint(Double, ModelParameters, Boolean)</h4>
  <div class="markdown level1 summary"><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Verifies the lifting point can be inserted at a valid point without collisions</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static bool ValidateLiftPoint(double x, ModelParameters modelParameters, bool isTop)</code></pre>
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
        <td><span class="parametername">x</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="1" sourceendlinenumber="1">x coordinate to insert the new lifting point at </p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.ModelParameters.html">ModelParameters</a></td>
        <td><span class="parametername">modelParameters</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td><span class="parametername">isTop</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="1" sourceendlinenumber="1">True if the parent is the top B1 member, False otherwise </p>
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
        <td><span class="xref">System.Boolean</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.LiftPoint.yml" sourcestartlinenumber="1" sourceendlinenumber="1">True if insertion is possible, false otherwise </p>
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
