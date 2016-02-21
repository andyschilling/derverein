$here = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)";
$psakePath = Join-Path $here -Child "lib\psake\psake.psm1";
Import-Module $psakePath;

invoke-psake "$here/default.ps1" -Task BuildSolution -Parameters @{ 'p'="Any CPU";'c'="Debug" };
