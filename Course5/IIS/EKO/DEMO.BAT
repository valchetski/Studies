:a
@movie EGA possmove
@if exist example.exp goto m1
@goto m2
:m1
@del example.exp
:m2
@rename demo1.erb eko%1.erb
@ekofr eko%1
@rename eko%1.erb demo1.erb
@if exist example.exp goto m3
@rename demo1.erb eko%1.erb
@ekofr eko%1
@rename eko%1.erb demo1.erb
@goto m4
:m3
@rename demo2.erb eko%1.erb
@ekofr eko%1
@rename eko%1.erb demo2.erb
:m4
@goto a
