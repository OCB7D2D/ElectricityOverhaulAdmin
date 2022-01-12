@echo off

call MC7D2D ElectricityOverhaulAdmin.dll /reference:"..\ElectricityOverhaul\build\Assembly-CSharp.dll";"..\ElectricityOverhaul\ElectricityOverhaul.dll" Harmony\*.cs && ^
echo Successfully compiled ElectricityOverhaulAdmin.dll

pause