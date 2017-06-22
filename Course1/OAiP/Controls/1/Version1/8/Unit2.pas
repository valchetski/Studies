unit Unit2;
Interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Buttons, TeEngine, Series, TeeProcs, Chart;

Type Complex=record
		 re,im:extended
		 end;
     fun = function(x:extended):complex;
     
function Mulc(x,y:Complex):Complex;
procedure tabf(var crt:tchart; a,b:extended; n:integer; f:fun);

Implementation
function Mulc;
begin
Mulc.re:=(x.re*y.re+x.im*y.im)/(sqr(y.re)+sqr(y.im));
Mulc.im:=(x.im*y.re-x.re*y.im)/(sqr(y.re)+sqr(y.im));
end;
procedure tabf;
var h,x:extended;
y:complex;
i:integer;
begin
 h:=(b-a)/n;
 x:=a;
 crt.SeriesList[0].Clear;
 crt.SeriesList[1].Clear;
 for i:=1 to n+1 do
 begin
 y:=f(x);
 crt.SeriesList[0].addxy(x,y.re);
 crt.SeriesList[1].addxy(x,y.im);
 x:=x+h;
 end;
end;
end.
