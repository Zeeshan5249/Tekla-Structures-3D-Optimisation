﻿<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class Box
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class Box
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
            <article class="content wrap" id="_content" data-uid="TeklaBillboardAid.Box">
  
  
  <h1 id="TeklaBillboardAid_Box" data-uid="TeklaBillboardAid.Box" class="text-break">Class Box
  </h1>
  <div class="markdown level0 summary"><p>Represents a box that is used to fill up each setion in a billboard with splits.</p>
</div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">Box</span></div>
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
  <h5 id="TeklaBillboardAid_Box_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public class Box</code></pre>
  </div>
  <h3 id="constructors">Constructors
  </h3>
  
  
  <a id="TeklaBillboardAid_Box__ctor_" data-uid="TeklaBillboardAid.Box.#ctor*"></a>
  <h4 id="TeklaBillboardAid_Box__ctor_System_Collections_Generic_List_System_Double__System_Collections_Generic_List_System_Double__System_Collections_Generic_List_System_Double__System_Double_System_Double_Tekla_Structures_Geometry3d_Point_System_Boolean_System_Boolean_System_Boolean_System_Boolean_System_Boolean_TeklaBillboardAid_ModelParameters_System_Boolean_System_Boolean_System_Boolean_System_Double_System_Double_" data-uid="TeklaBillboardAid.Box.#ctor(System.Collections.Generic.List{System.Double},System.Collections.Generic.List{System.Double},System.Collections.Generic.List{System.Double},System.Double,System.Double,Tekla.Structures.Geometry3d.Point,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Boolean,TeklaBillboardAid.ModelParameters,System.Boolean,System.Boolean,System.Boolean,System.Double,System.Double)">Box(List&lt;Double&gt;, List&lt;Double&gt;, List&lt;Double&gt;, Double, Double, Point, Boolean, Boolean, Boolean, Boolean, Boolean, ModelParameters, Boolean, Boolean, Boolean, Double, Double)</h4>
  <div class="markdown level1 summary"><p>The constructor for a box, which generates a model section in the billboard.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Box(List&lt;double&gt; zSubCoordinates, List&lt;double&gt; xSubCoordinates, List&lt;double&gt; walkwaySubList, double boxHeight, double boxLength, Point OriginOffset, bool side1, bool side2, bool side3, bool side4, bool StructureAutoRadio, ModelParameters modelParameters, bool HatchFlag = false, bool IsLeftHatch = false, bool TopHatchFlag = false, double HatchDistanceFromLadder = 0, double HatchWidth = 0)</code></pre>
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
        <td><span class="parametername">zSubCoordinates</span></td>
        <td><p>The vertical height of where the box is constructed</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">System.Double</span>&gt;</td>
        <td><span class="parametername">xSubCoordinates</span></td>
        <td><p>The horizontal distances of where vertical columns go</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">System.Double</span>&gt;</td>
        <td><span class="parametername">walkwaySubList</span></td>
        <td><p>A list of the vertical positions of where walkways are positioned </p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">boxHeight</span></td>
        <td><p>The height of the box</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">boxLength</span></td>
        <td><p>The length of the box</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">OriginOffset</span></td>
        <td><p>A TSG point reference for the position of the box</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td><span class="parametername">side1</span></td>
        <td><p>Indicates if front is selected</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td><span class="parametername">side2</span></td>
        <td><p>Indicates if left is selected</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td><span class="parametername">side3</span></td>
        <td><p>Indicates if back is selected</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td><span class="parametername">side4</span></td>
        <td><p>Indicates if right is selected</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td><span class="parametername">StructureAutoRadio</span></td>
        <td><p>Used to indicate to create intermediate horizontal railing supports</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.ModelParameters.html">ModelParameters</a></td>
        <td><span class="parametername">modelParameters</span></td>
        <td><p>The parameters of the model</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td><span class="parametername">HatchFlag</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td><span class="parametername">IsLeftHatch</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.Boolean</span></td>
        <td><span class="parametername">TopHatchFlag</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">HatchDistanceFromLadder</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">HatchWidth</span></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="properties">Properties
  </h3>
  
  
  <a id="TeklaBillboardAid_Box_B1Beam1_" data-uid="TeklaBillboardAid.Box.B1Beam1*"></a>
  <h4 id="TeklaBillboardAid_Box_B1Beam1" data-uid="TeklaBillboardAid.Box.B1Beam1">B1Beam1</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Beam B1Beam1 { get; set; }</code></pre>
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
        <td><p>Represents the first B1 Beam in a rectangle</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Box_B1Beam2_" data-uid="TeklaBillboardAid.Box.B1Beam2*"></a>
  <h4 id="TeklaBillboardAid_Box_B1Beam2" data-uid="TeklaBillboardAid.Box.B1Beam2">B1Beam2</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Beam B1Beam2 { get; set; }</code></pre>
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
        <td><p>Represents the second B1 Beam in a rectangle</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Box_B1Beam3_" data-uid="TeklaBillboardAid.Box.B1Beam3*"></a>
  <h4 id="TeklaBillboardAid_Box_B1Beam3" data-uid="TeklaBillboardAid.Box.B1Beam3">B1Beam3</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Beam B1Beam3 { get; set; }</code></pre>
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
        <td><p>Represents the third B1 Beam in a rectangle</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Box_B1Beam4_" data-uid="TeklaBillboardAid.Box.B1Beam4*"></a>
  <h4 id="TeklaBillboardAid_Box_B1Beam4" data-uid="TeklaBillboardAid.Box.B1Beam4">B1Beam4</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Beam B1Beam4 { get; set; }</code></pre>
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
        <td><p>Represents the fourth B1 Beam in a rectangle</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Box_BoxOrigin_" data-uid="TeklaBillboardAid.Box.BoxOrigin*"></a>
  <h4 id="TeklaBillboardAid_Box_BoxOrigin" data-uid="TeklaBillboardAid.Box.BoxOrigin">BoxOrigin</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Point BoxOrigin { get; set; }</code></pre>
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
        <td><p>A TSG point representing the origin position of the box</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Box_Height_" data-uid="TeklaBillboardAid.Box.Height*"></a>
  <h4 id="TeklaBillboardAid_Box_Height" data-uid="TeklaBillboardAid.Box.Height">Height</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public double Height { get; set; }</code></pre>
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
        <td><span class="xref">System.Double</span></td>
        <td><p>Indicates the height of the box</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Box_Length_" data-uid="TeklaBillboardAid.Box.Length*"></a>
  <h4 id="TeklaBillboardAid_Box_Length" data-uid="TeklaBillboardAid.Box.Length">Length</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public double Length { get; set; }</code></pre>
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
        <td><span class="xref">System.Double</span></td>
        <td><p>Indicates the length of the box</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Box_Planes_" data-uid="TeklaBillboardAid.Box.Planes*"></a>
  <h4 id="TeklaBillboardAid_Box_Planes" data-uid="TeklaBillboardAid.Box.Planes">Planes</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public List&lt;Frame&gt; Planes { get; set; }</code></pre>
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
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<a class="xref" href="TeklaBillboardAid.Frame.html">Frame</a>&gt;</td>
        <td><p>A list of frames for the planes of the box</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Box_Side1_" data-uid="TeklaBillboardAid.Box.Side1*"></a>
  <h4 id="TeklaBillboardAid_Box_Side1" data-uid="TeklaBillboardAid.Box.Side1">Side1</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public bool Side1 { get; set; }</code></pre>
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
        <td><p>Represents the front side of the billboard</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Box_Side2_" data-uid="TeklaBillboardAid.Box.Side2*"></a>
  <h4 id="TeklaBillboardAid_Box_Side2" data-uid="TeklaBillboardAid.Box.Side2">Side2</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public bool Side2 { get; set; }</code></pre>
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
        <td><p>Represents the left side of the billboard</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Box_Side3_" data-uid="TeklaBillboardAid.Box.Side3*"></a>
  <h4 id="TeklaBillboardAid_Box_Side3" data-uid="TeklaBillboardAid.Box.Side3">Side3</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public bool Side3 { get; set; }</code></pre>
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
        <td><p>Represents the back side of the billboard</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Box_Side4_" data-uid="TeklaBillboardAid.Box.Side4*"></a>
  <h4 id="TeklaBillboardAid_Box_Side4" data-uid="TeklaBillboardAid.Box.Side4">Side4</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public bool Side4 { get; set; }</code></pre>
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
        <td><p>Represents the right side of the billboard</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Box_XSubCoordinates_" data-uid="TeklaBillboardAid.Box.XSubCoordinates*"></a>
  <h4 id="TeklaBillboardAid_Box_XSubCoordinates" data-uid="TeklaBillboardAid.Box.XSubCoordinates">XSubCoordinates</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public List&lt;double&gt; XSubCoordinates { get; set; }</code></pre>
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
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">System.Double</span>&gt;</td>
        <td><p>Indicates the x positions where vertical supports in the box are to be placed</p>
</td>
      </tr>
    </tbody>
  </table>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="TeklaBillboardAid_Box_CreateBeam_" data-uid="TeklaBillboardAid.Box.CreateBeam*"></a>
  <h4 id="TeklaBillboardAid_Box_CreateBeam_System_String_System_String_Tekla_Structures_Geometry3d_Point_Tekla_Structures_Geometry3d_Point_System_String_System_String_System_String_System_Int32___System_Double___System_String_TeklaBillboardAid_ModelParameters_System_String_Tekla_Structures_Geometry3d_Point_" data-uid="TeklaBillboardAid.Box.CreateBeam(System.String,System.String,Tekla.Structures.Geometry3d.Point,Tekla.Structures.Geometry3d.Point,System.String,System.String,System.String,System.Int32[],System.Double[],System.String,TeklaBillboardAid.ModelParameters,System.String,Tekla.Structures.Geometry3d.Point)">CreateBeam(String, String, Point, Point, String, String, String, Int32[], Double[], String, ModelParameters, String, Point)</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static Beam CreateBeam(string partprefix, string assprefix, Point startPos, Point endPos, string material, string profile, string beamClass, int[] enums, double[] offsets, string beamFinish = &quot;&quot;, ModelParameters modelParameters = null, string parentProfile = &quot;&quot;, Point cutOrigin = null)</code></pre>
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
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">partprefix</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">assprefix</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">startPos</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">endPos</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">material</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">profile</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">beamClass</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.Int32</span>[]</td>
        <td><span class="parametername">enums</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span>[]</td>
        <td><span class="parametername">offsets</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">beamFinish</span></td>
        <td></td>
      </tr>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.ModelParameters.html">ModelParameters</a></td>
        <td><span class="parametername">modelParameters</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">System.String</span></td>
        <td><span class="parametername">parentProfile</span></td>
        <td></td>
      </tr>
      <tr>
        <td><span class="xref">Tekla.Structures.Geometry3d.Point</span></td>
        <td><span class="parametername">cutOrigin</span></td>
        <td></td>
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
        <td><span class="xref">Tekla.Structures.Model.Beam</span></td>
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
