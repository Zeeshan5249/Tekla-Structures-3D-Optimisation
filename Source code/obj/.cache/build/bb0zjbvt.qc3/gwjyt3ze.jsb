<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class ZBracket
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class ZBracket
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
            <article class="content wrap" id="_content" data-uid="TeklaBillboardAid.ZBracket">
  
  
  <h1 id="TeklaBillboardAid_ZBracket" data-uid="TeklaBillboardAid.ZBracket" class="text-break">Class ZBracket
  </h1>
  <div class="markdown level0 summary"><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Class to support modelling of Z-brackets on Tekla Structures.</p>
</div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">ZBracket</span></div>
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
  <h5 id="TeklaBillboardAid_ZBracket_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public class ZBracket</code></pre>
  </div>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="TeklaBillboardAid_ZBracket_CreatePolyBeam_" data-uid="TeklaBillboardAid.ZBracket.CreatePolyBeam*"></a>
  <h4 id="TeklaBillboardAid_ZBracket_CreatePolyBeam_System_Collections_Generic_List_Tekla_Structures_Model_ContourPoint__System_String_System_String_System_Int32___System_Double___System_String_System_String_" data-uid="TeklaBillboardAid.ZBracket.CreatePolyBeam(System.Collections.Generic.List{Tekla.Structures.Model.ContourPoint},System.String,System.String,System.Int32[],System.Double[],System.String,System.String)">CreatePolyBeam(List&lt;ContourPoint&gt;, String, String, Int32[], Double[], String, String)</h4>
  <div class="markdown level1 summary"><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Method to create a PolyBeam model on Tekla Structures.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static PolyBeam CreatePolyBeam(List&lt;ContourPoint&gt; points, string profile, string material, int[] bracketEnums, double[] bracketOffsets, string beamClass, string beamFinish = &quot;&quot;)</code></pre>
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
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">Tekla.Structures.Model.ContourPoint</span>&gt;</td>
        <td><span class="parametername">points</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="1" sourceendlinenumber="1">List of ContourPoints in clockwise or counterclockwise order in the beam&apos;s cross section (mm)</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">profile</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The beam&apos;s profile </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">material</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The beam&apos;s material </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Int32</span>[]</td>
        <td><span class="parametername">bracketEnums</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Array in the form [Position.DepthEnum, Position.PlaneEnum, Position.RotationEnum] </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span>[]</td>
        <td><span class="parametername">bracketOffsets</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Offsets in the form [depthOffset, planeOffset, rotationOffset] </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">beamClass</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The beam&apos;s class e.g. beamClass : &quot;1&quot; </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">beamFinish</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Finish field of the part </p>
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
        <td><span class="xref">Tekla.Structures.Model.PolyBeam</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Part in Tekla Structures. </p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_ZBracket_ZBrackets_" data-uid="TeklaBillboardAid.ZBracket.ZBrackets*"></a>
  <h4 id="TeklaBillboardAid_ZBracket_ZBrackets_System_Collections_Generic_List_System_Double__Tekla_Structures_Geometry3d_Point_System_Collections_Generic_List_TeklaBillboardAid_Frame__System_Collections_Generic_List_System_Double__TeklaBillboardAid_ModelParameters_" data-uid="TeklaBillboardAid.ZBracket.ZBrackets(System.Collections.Generic.List{System.Double},Tekla.Structures.Geometry3d.Point,System.Collections.Generic.List{TeklaBillboardAid.Frame},System.Collections.Generic.List{System.Double},TeklaBillboardAid.ModelParameters)">ZBrackets(List&lt;Double&gt;, Point, List&lt;Frame&gt;, List&lt;Double&gt;, ModelParameters)</h4>
  <div class="markdown level1 summary"><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Populates the billboard model with Z-brackets at given z-coordinates.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static List&lt;Part&gt; ZBrackets(List&lt;double&gt; xSubCoordinates, Point OriginOffset, List&lt;Frame&gt; planes, List&lt;double&gt; zCoordinatesForZBrackets, ModelParameters modelParameters)</code></pre>
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
        <td><span class="parametername">xSubCoordinates</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">OriginOffset</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<a class="xref" href="TeklaBillboardAid.Frame.html">Frame</a>&gt;</td>
        <td><span class="parametername">planes</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="1" sourceendlinenumber="1">List of frames sorted by x-coordinates to insert the Z-brackets behind </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">System.Double</span>&gt;</td>
        <td><span class="parametername">zCoordinatesForZBrackets</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="1" sourceendlinenumber="1">List of z-coordinates to insert the Z-brackets along (mm) </p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.ModelParameters.html">ModelParameters</a></td>
        <td><span class="parametername">modelParameters</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.ZBracket.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The model&apos;s data store </p>
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
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">Tekla.Structures.Model.Part</span>&gt;</td>
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
