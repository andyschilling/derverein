Framework 4.5.1

properties {
    $platform = $p;
    $configuration = $c

    $solution_name = "DerVerein"
    $base_directory = Resolve-Path .
    $project_dir = "$base_directory\src\$solution_name"
    $properties_file = "$project_dir\DerVerein\Properties\AssemblyInfo.cs"
    $solution_file = "$base_directory\src\$solution_name\$solution_name.sln"
    $output_dir = "$base_directory\output\$p\$c"

    $max_cpu_count = [System.Environment]::ProcessorCount / 2
    $build_in_parralel = $true
}

Task default -Depends BuildSolution

Task BuildSolution -Depends Clean, IncrementVersion {
    Write-Host "Building solution";

    exec { msbuild /m:$max_cpu_count /p:BuildInParralel=$build_in_parralel /p:Configuration="$configuration" /p:Platform=$platform /p:OutDir="$output_dir"\\ "$solution_file" };

    Write-Host "Solution build!";
}

Task Clean { 
    Write-Host "Doing clean up before starting a build!";

    exec { msbuild "$solution_file" '/t:Clean' };

    Remove-Item -Path $output_dir -Recurse -Force -ErrorAction ("SilentlyContinue");
    New-Item -Path $output_dir -itemType directory
}

Task IncrementVersion {
    Write-Host "Incrementing Version"

    exec { .\lib\UpdateVersion\UpdateVersion.exe -i $properties_file -o $properties_file -v Assembly -s 2016-02-01 -b BuildDay -r Automatic }

    exec { .\lib\UpdateVersion\UpdateVersion.exe -i $properties_file -o $properties_file -v File -s 2016-02-01 -b BuildDay -r Automatic }
}