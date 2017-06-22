unit Unit2;

interface

type
   Tkey=integer;
   tinf=record
      f:string[50];
      k:Tkey;
   end;

   Psel=^sel;
   sel=record
      inf:Tinf;
      a:psel;
   end;


   Tzad=class(Tobject)
      sp,sp1:Psel;
      constructor create;
      procedure add1(inf:Tinf);
      procedure read1(var Inf:Tinf);
      procedure sort;
   end;


implementation


constructor Tzad.create;
begin
   inherited create;
   new(sp1);
   sp1.a:=nil;
end;



procedure Tzad.add1;
begin
   new(sp);
   sp.inf:=inf;
   sp.a:=sp1.a;
   sp1.a:=sp;
end;


procedure Tzad.read1;
begin
   sp:=sp1.a;
   inf:=sp.inf;
   sp1.a:=sp.a;
   dispose(sp);
end;



procedure Tzad.sort;
   procedure revafter(spi:Psel);
   var p:Psel;
   begin
      p:=spi.a.a;
      spi.a.a:=p.a;
      p.a:=spi.a;
      spi.a:=p;
   end;
var spt:Psel;
begin
   spt:=nil;
   repeat
      sp:=sp1;
      while sp.a.a<>spt do
      begin
         if sp.a.inf.k>sp.a.a.inf.k then revafter(sp);
         sp:=sp.a;
      end;
      spt:=sp.a;
   until spt=sp1.a.a;
end;





end.
 