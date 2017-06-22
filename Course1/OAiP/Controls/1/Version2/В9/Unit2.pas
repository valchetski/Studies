unit Unit2;

interface

	type Tfn=function(x:extended):extended;
  function Intgf(a,b:extended;n:word; F:Tfn):extended;

implementation
	function Intgf(a,b:extended;n:word; F:Tfn):extended;
		  Var s,h,x:extended;
			  i:word;
		  begin
			h:=(b-a)/n; x:=0;
                  s:=0;
			for i:=1 to n do
				begin
        x:=a+h*(i-0.5);
				  s:=s+F(x);

				end;
          Result:=h*s;
		  end;
end.
 