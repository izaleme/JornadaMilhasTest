# Jornada Milhas Test

<h4 align="center"> 
    :construction:  Project under construction  :construction:
</h4>

### Automated Tests with .NET
<p>This repository presents an <b>automated testing project</b> using the .NET platform. To implement the tests, the xUnit library was selected, one of the most robust and popular for the .NET ecosystem.</p>
<p>The focus of this project is the "Jornada Milhas" application, a travel offers platform.</p>
<p>Here, you will find the testing framework, practical examples and the configuration necessary to run and validate the application's automated tests.</p>

##
### Features
- [x] Create automated tests using the XUnit library
- [x] Write unit tests to ensure code quality
- [x] Apply the AAA standard to write tests with more clarity and organization
- [x] Restructure the test nomenclature following a conventional naming standard
- [x] Test different sets of data in the same test, using Theory
- [x] Solving mutation testing problems with Theory

##
### Installations
<p>It is necessary to install the Stryker .NET library to perform mutation testing.</p>
<li>Right-click on the JornadaMilhas.Test project --> Open in terminal --> paste the command <i>dotnet tool install -g dotnet-stryker</i></li>
<li>To run Stryker inside the project --> <i>dotnet stryker</i></li> <br>

##
### Observations:

#### Test standardization
<p>There is a testing pattern called the <b>AAA (triple A)</b> pattern, which consists of:</p>
<ul>
<li>Arrange (Scenario)</li>
<li>Act (Action)</li>
<li>Assert (Validation)</li>
</ul>
<p>The purpose of the <b>Assert</b> is to ensure that the behavior of the tested code aligns with the expected outcomes, providing immediate feedback.</p>
<p>There is also the <b>Given-When-Then pattern</b>, which is similar but more behavior-oriented than structurally oriented like the AAA pattern.</p>
<br>

#### Nomenclature standardization
<p>A good naming pattern uses the name of the method being tested, the scenario and the expected behavior.</p>
<p>The detailed specification that describes the conditions, inputs, procedures and expected results to verify that a particular system component is working correctly is called a test case.</p>
<br>

#### xUnit Notations
<p>xUnity Theory helps you test multiple different scenarios in the same test scenario. It helps to have cleaner, more readable and high-quality test code.</p>
<ul>In addition to Fact and Theory, there are other xUnit notations that can be used:
<li>[TestFixture] - a class that contains a set of related unit tests</li>
<li>[Test] - used to identify different tests within the same test class</li>
<li>[Ignore] - used to ignore a specific test during execution</li>
<li>[Collection] - used to group tests into specific collections</li>
</ul><br>

### Mutation Testing
<p>Mutation testing is an advanced software testing technique designed to evaluate the effectiveness of unit tests by identifying gaps in code coverage. It is particularly useful for detecting semantic changes in the code that could introduce bugs. The process follows these steps:</p>
<li><b>Apply mutations:</b> Automated modifications simulate small errors in the code.</li>
<li><b>Run tests:</b> Checks whether the tests detect the changes (kills the mutants).</li>
<li><b>Assess coverage:</b> A high number of undetected mutants indicates insufficient test coverage.</li>
<li><b>Improve tests:</b> Tests are refined or added to enhance their effectiveness.</li>
