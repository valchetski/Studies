@echo off
echo off
if exist example.exp goto m1:
goto m2:
:m1
del example.exp
:m2
rename demo1.erb eko%1.erb
ekofr eko%1
rename eko%1.erb demo1.erb

