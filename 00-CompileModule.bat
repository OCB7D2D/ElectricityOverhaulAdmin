@echo off

call MC7D2D ElectricityOverhaulAdmin.dll /reference:"%PATH_7D2D_MANAGED%\Assembly-CSharp.dll";"..\ElectricityOverhaul\ElectricityOverhaul.dll" Harmony\*.cs && ^
echo Successfully compiled ElectricityOverhaulAdmin.dll

pause