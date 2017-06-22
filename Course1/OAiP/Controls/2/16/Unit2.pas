unit Unit2;

interface
const nok=0;
type
   tkey=integer;
   tinf=record
      f:string[50];
      k:Tkey;
   end;
   Psel=^sel;
   sel=record
      inf:Tinf;
      a:Psel;
   end;
   mas=array [1..1] of Psel;
   Pmas=^mas;

   Tzad=class(Tobject)
      M:word;
      H:Pmas;
      sp:Psel;
      constructor create(M0:word);
      procedure add(inf:Tinf);
      function read(key:Tkey):Tinf;
   end;

implementation

constructor Tzad.create;
var I:word;
begin
   M:=M0;
   getmem(H,M*4);
   for i:=1 to m-1 do
      h[i]:=nil;
end;


procedure Tzad.add;
var i:word;
begin
   i:=inf.k mod M;
   new(sp);
   sp.inf:=inf;
   sp.a:=h[i];
   h[i]:=sp;
end;



function Tzad.read;
var i:word;
begin
   i:=key mod M;
   sp:=h[i];
   while (sp<>nil) and(sp.inf.k<>key) do
      sp:=sp.a;
   if sp<>nil then result:=sp.inf
   else result.k:=nok;

end;

end.
 