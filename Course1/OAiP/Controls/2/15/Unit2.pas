unit Unit2;

interface
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
   mas=array[1..30]of tinf;
   Tzad=class(Tobject)
      p,proot,q,w:ptree;
      constructor create;
      procedure Blns(a:mas;n:word);
      function mink:Tinf;
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



procedure Tzad.Blns;
   function bl(L,R:word):ptree;
   var p:ptree; m:word;
   begin
      if R<L then p:=nil
      else
      begin
         m:=(L+R) div 2;
         new(p);
         p.inf:=a[m];
         p.a1:=bl(L,m-1);
         p.a2:=bl(m+1,R);
      end;
      result:=p;
   end;
begin
   proot:=bl(1,n);
end;


function Tzad.mink;
begin
   p:=proot;
   while p.a1<>nil do
      p:=p.a1;
   result:=p.inf;
end;

end.
 