@echo off
echo off

if exist example.exp goto m1:
rename demo1.erb eko%1.erb
ekofr eko%1
rename eko%1.erb demo1.erb
goto m2:
:m1
rename demo2.erb eko%1.erb
ekofr eko%1
rename eko%1.erb demo2.erb
:m2


