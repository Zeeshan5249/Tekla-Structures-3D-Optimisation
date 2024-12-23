<!DOCTYPE html>
<!--[if IE]><![endif]-->
<html>
  
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>Class Cladding
   </title>
    <meta name="viewport" content="width=device-width">
    <meta name="title" content="Class Cladding
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
            <article class="content wrap" id="_content" data-uid="TeklaBillboardAid.Cladding">
  
  
  <h1 id="TeklaBillboardAid_Cladding" data-uid="TeklaBillboardAid.Cladding" class="text-break">Class Cladding
  </h1>
  <div class="markdown level0 summary"><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Class to support modeling of cladding on the exteriors of the billboard.</p>
</div>
  <div class="markdown level0 conceptual"></div>
  <div class="inheritance">
    <h5>Inheritance</h5>
    <div class="level0"><span class="xref">System.Object</span></div>
    <div class="level1"><span class="xref">Cladding</span></div>
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
  <h5 id="TeklaBillboardAid_Cladding_syntax">Syntax</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public class Cladding</code></pre>
  </div>
  <h3 id="constructors">Constructors
  </h3>
  
  
  <a id="TeklaBillboardAid_Cladding__ctor_" data-uid="TeklaBillboardAid.Cladding.#ctor*"></a>
  <h4 id="TeklaBillboardAid_Cladding__ctor_TeklaBillboardAid_CladdingType_TeklaBillboardAid_ModelParameters_TeklaBillboardAid_BillboardSide_TeklaBillboardAid_Colour_System_Double_System_Double_" data-uid="TeklaBillboardAid.Cladding.#ctor(TeklaBillboardAid.CladdingType,TeklaBillboardAid.ModelParameters,TeklaBillboardAid.BillboardSide,TeklaBillboardAid.Colour,System.Double,System.Double)">Cladding(CladdingType, ModelParameters, BillboardSide, Colour, Double, Double)</h4>
  <div class="markdown level1 summary"><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">The constructor for the cladding. Upon creating an instance, the program will generate the cladding for the model.</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Cladding(CladdingType type, ModelParameters modelParameters, BillboardSide side, Colour colour, double openArea, double thickness)</code></pre>
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
        <td><a class="xref" href="TeklaBillboardAid.CladdingType.html">CladdingType</a></td>
        <td><span class="parametername">type</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Indicates which type of cladding is to be created</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.ModelParameters.html">ModelParameters</a></td>
        <td><span class="parametername">modelParameters</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="1" sourceendlinenumber="1">The parameters of the model</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.BillboardSide.html">BillboardSide</a></td>
        <td><span class="parametername">side</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Indicates which side the cladding is being inserted</p>
</td>
      </tr>
      <tr>
        <td><a class="xref" href="TeklaBillboardAid.Colour.html">Colour</a></td>
        <td><span class="parametername">colour</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Indicates the colour of the cladding</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">openArea</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Indicates the open area for the profile</p>
</td>
      </tr>
      <tr>
        <td><span class="xref">System.Double</span></td>
        <td><span class="parametername">thickness</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Indicates the thickness of the cladding</p>
</td>
      </tr>
    </tbody>
  </table>
  <h3 id="properties">Properties
  </h3>
  
  
  <a id="TeklaBillboardAid_Cladding_Beams_" data-uid="TeklaBillboardAid.Cladding.Beams*"></a>
  <h4 id="TeklaBillboardAid_Cladding_Beams" data-uid="TeklaBillboardAid.Cladding.Beams">Beams</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public List&lt;Beam&gt; Beams { get; set; }</code></pre>
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
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<span class="xref">Tekla.Structures.Model.Beam</span>&gt;</td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">A list of beams being inserted to represent MiniOrb and PanelRib claddings</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Cladding_Colour_" data-uid="TeklaBillboardAid.Cladding.Colour*"></a>
  <h4 id="TeklaBillboardAid_Cladding_Colour" data-uid="TeklaBillboardAid.Cladding.Colour">Colour</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public Colour Colour { get; set; }</code></pre>
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
        <td><a class="xref" href="TeklaBillboardAid.Colour.html">Colour</a></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Colour of cladding sheet.</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Cladding_Material_" data-uid="TeklaBillboardAid.Cladding.Material*"></a>
  <h4 id="TeklaBillboardAid_Cladding_Material" data-uid="TeklaBillboardAid.Cladding.Material">Material</h4>
  <div class="markdown level1 summary"></div>
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
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Material of Beam.</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Cladding_PercentOpenArea_" data-uid="TeklaBillboardAid.Cladding.PercentOpenArea*"></a>
  <h4 id="TeklaBillboardAid_Cladding_PercentOpenArea" data-uid="TeklaBillboardAid.Cladding.PercentOpenArea">PercentOpenArea</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public double PercentOpenArea { get; set; }</code></pre>
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
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Indicates the user input of open area for perforated sheet profiles</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Cladding_Plates_" data-uid="TeklaBillboardAid.Cladding.Plates*"></a>
  <h4 id="TeklaBillboardAid_Cladding_Plates" data-uid="TeklaBillboardAid.Cladding.Plates">Plates</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public List&lt;Plate&gt; Plates { get; set; }</code></pre>
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
        <td><span class="xref">System.Collections.Generic.List</span>&lt;<a class="xref" href="TeklaBillboardAid.Plate.html">Plate</a>&gt;</td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">A list of plates being inserted to represent ACM and PerfSheet claddings</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Cladding_Profile_" data-uid="TeklaBillboardAid.Cladding.Profile*"></a>
  <h4 id="TeklaBillboardAid_Cladding_Profile" data-uid="TeklaBillboardAid.Cladding.Profile">Profile</h4>
  <div class="markdown level1 summary"></div>
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
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Profile of Beam based on cladding material.</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Cladding_Side_" data-uid="TeklaBillboardAid.Cladding.Side*"></a>
  <h4 id="TeklaBillboardAid_Cladding_Side" data-uid="TeklaBillboardAid.Cladding.Side">Side</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public BillboardSide Side { get; set; }</code></pre>
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
        <td><a class="xref" href="TeklaBillboardAid.BillboardSide.html">BillboardSide</a></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Indicates which side of the billboard has cladding being applied</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Cladding_Thickness_" data-uid="TeklaBillboardAid.Cladding.Thickness*"></a>
  <h4 id="TeklaBillboardAid_Cladding_Thickness" data-uid="TeklaBillboardAid.Cladding.Thickness">Thickness</h4>
  <div class="markdown level1 summary"></div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public double Thickness { get; set; }</code></pre>
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
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Indicates the thickness of the cladding</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Cladding_Type_" data-uid="TeklaBillboardAid.Cladding.Type*"></a>
  <h4 id="TeklaBillboardAid_Cladding_Type" data-uid="TeklaBillboardAid.Cladding.Type">Type</h4>
  <div class="markdown level1 summary"><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">Indicates the cladding type currently being used</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public CladdingType Type { get; set; }</code></pre>
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
        <td><a class="xref" href="TeklaBillboardAid.CladdingType.html">CladdingType</a></td>
        <td></td>
      </tr>
    </tbody>
  </table>
  <h3 id="methods">Methods
  </h3>
  
  
  <a id="TeklaBillboardAid_Cladding_ColourToClass_" data-uid="TeklaBillboardAid.Cladding.ColourToClass*"></a>
  <h4 id="TeklaBillboardAid_Cladding_ColourToClass_TeklaBillboardAid_Colour_" data-uid="TeklaBillboardAid.Cladding.ColourToClass(TeklaBillboardAid.Colour)">ColourToClass(Colour)</h4>
  <div class="markdown level1 summary"><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">A method to convert a provided colour into a string to be used to represent the cladding profile colour</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static string ColourToClass(Colour colour)</code></pre>
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
        <td><a class="xref" href="TeklaBillboardAid.Colour.html">Colour</a></td>
        <td><span class="parametername">colour</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Indicates the colour to be converted to a numerical string</p>
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
        <td><span class="xref">System.String</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="1" sourceendlinenumber="1">A string containing an integer</p>
</td>
      </tr>
    </tbody>
  </table>
  
  
  <a id="TeklaBillboardAid_Cladding_ColourToFinish_" data-uid="TeklaBillboardAid.Cladding.ColourToFinish*"></a>
  <h4 id="TeklaBillboardAid_Cladding_ColourToFinish_TeklaBillboardAid_Colour_" data-uid="TeklaBillboardAid.Cladding.ColourToFinish(TeklaBillboardAid.Colour)">ColourToFinish(Colour)</h4>
  <div class="markdown level1 summary"><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="2" sourceendlinenumber="2">A method to convert a provided finish into a string to be used to represent the cladding profile finish</p>
</div>
  <div class="markdown level1 conceptual"></div>
  <h5 class="decalaration">Declaration</h5>
  <div class="codewrapper">
    <pre><code class="lang-csharp hljs">public static string ColourToFinish(Colour colour)</code></pre>
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
        <td><a class="xref" href="TeklaBillboardAid.Colour.html">Colour</a></td>
        <td><span class="parametername">colour</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="1" sourceendlinenumber="1">Indicates the finish to be converted </p>
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
        <td><span class="xref">System.String</span></td>
        <td><p sourcefile="obj/api/TeklaBillboardAid.Cladding.yml" sourcestartlinenumber="1" sourceendlinenumber="1">A string containing a colour option</p>
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
