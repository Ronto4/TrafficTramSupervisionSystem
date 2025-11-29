# Source: https://wiki.nixos.org/wiki/DotNET#Example:_Running_Rider_with_dotnet_&_PowerShell

with import <nixpkgs> {};

mkShell {
  name = "dotnet-env";
  packages = [
    (with dotnetCorePackages; combinePackages [
      sdk_8_0
      sdk_9_0
    ])
    powershell
    jetbrains.rider
    # To allow debugging Blazor WASM...
    chromium
    # Source: https://wiki.nixos.org/wiki/Python
    (pkgs.python3.withPackages (python-pkgs: with python-pkgs; [
      # select Python packages here
      # requests
      # beautifulsoup4
      # curlify
    ]))
  ];
}
