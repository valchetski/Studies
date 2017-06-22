unit Unit2;

interface
uses graphics;

type
   tviz=class(Tobject)
      krc,kvc,bgc:Tcolor;
      x,y,r:integer;
      canvas:Tcanvas;

      procedure ris; virtual; abstract;
      procedure draw(bl:boolean);
      procedure hide;
      procedure show;
      procedure moveto(dx,dy,dr:integer);
   end;


   Tkvkr=class(Tviz)
      constructor create(x0,y0,r0:integer;Canvas0:Tcanvas);
      procedure ris; override;
   end;

implementation



constructor Tkvkr.create;
begin
   inherited create;
   x:=x0;
   y:=y0;
   r:=r0;
   canvas:=canvas0;
   bgc:=clWhite;
end;



procedure Tviz.draw;
begin
   if bl then
   begin
      krc:=clgreen;
      kvc:=clred;
      canvas.Pen.Color:=clblack;
   end
   else
   begin
      krc:=clwhite;
      kvc:=clwhite;
      canvas.Pen.Color:=clwhite;
   end;
   ris;
end;




procedure Tviz.hide;
begin
   draw(false);
end;


procedure Tviz.show;
begin
   draw(true);
end;


procedure Tviz.moveto;
begin
   hide;
   x:=x+dx;
   y:=y+dy;
   r:=r+dr;
   show;
end;


procedure Tkvkr.ris;
begin
   with canvas do
   begin
      brush.Color:=kvc;
      rectangle(x-r,y-r,x+r,y+r);
      brush.Color:=krc;
      ellipse(x-r,y-r,x+r,y+r);

   end;
end;


end.
