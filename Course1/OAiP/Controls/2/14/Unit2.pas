unit Unit2;

interface
const nok=0;

type
   Tkey=integer;
   tinf=record
      f:String[50];
      k:Tkey;
   end;

   Ptree=^tree;
   tree=record
      inf:Tinf;
      a1,a2:Ptree;
   end;

   Tzad=class(Tobject)
      p,proot,q,w:ptree;
      constructor create;
      procedure AddB(inf:Tinf);
      function poiskb(k:tkey):Tinf;
      destructor free;
   end;

implementation



constructor Tzad.create;
begin
   inherited create;
   proot:=nil;
end;

destructor Tzad.free;
   procedure del(var P:ptree);
   begin
      if p<>nil then
      begin
         del(p.a1);
         del(p.a2);
         dispose(p);
         p:=nil;
      end;
   end;
begin
   del(proot);
   if self<>nil then
      inherited destroy;
end;




function Tzad.poiskb;
begin
   p:=proot;
   while (p<>nil) and (p.inf.k<>k) do
      if p.inf.k>k then p:=p.a1
      else p:=p.a2;
   if p<>nil then result:=p.inf
   else result.k:=nok;
end;



procedure tzad.AddB;
var bl:boolean;
begin
   new(w);
   w.inf:=inf;
   w.a1:=nil;
   w.a2:=nil;
   if proot=nil then
      proot:=w
   else
   begin
      p:=proot;
      repeat
         q:=p;
         bl:=inf.k<p.inf.k;
         if bl then p:=p.a1
         else p:=p.a2;
      until p=nil;

      if bl then q.a1:=w
      else q.a2:=w;
   end;
end;


end.
 