unit Unit2;

interface
uses  Chart;

 	Type Complex=record
			re,im:extended
		end;
Type fun=function(x:extended):complex;
Procedure
  Tabf(a,b:extended;n:word;f:fun;M:Tchart);

implementation
Procedure
  Tabf(a,b:extended;n:word;f:fun;M:Tchart);
  var h,x:extended; y:complex; i:word;
begin
m.SeriesList[0].Clear;
m.SeriesList[1].Clear;
    h:=(b-a)/n;
    x:=a;
  for i:=0 to n do begin
      y:=f(x);
      M.SeriesList[0].AddXY(x,y.re);
      m.SeriesList[1].AddXY(x,y.im);
      x:=x+h;
                   end;

  end;
end.
