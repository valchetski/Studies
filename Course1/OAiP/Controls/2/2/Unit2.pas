unit Unit2;

interface

const nok=0;
type
   Tkey=integer;

   Tinf=record
      f:string;
      k:Tkey;
   end;

   mas=array[1..50] of Tinf;

   tzad=class(Tobject)
      a:mas;
      n:integer;
      procedure sort;
      function poiskd(k:Tkey):Tinf;
   end;


implementation


procedure Tzad.sort;
var i,j:Integer; z:Tinf;
begin
   for i:=1 to n-1 do
      for j:=i+1 to n do
         if a[i].k>a[j].k then
         begin
            z:=a[i];
            a[i]:=a[j];
            a[j]:=z;
         end;

end;


function Tzad.poiskd;
var i:word;
   function del(L,R:word):word;
   var m:word;
   begin
      if r<=l then result:=r
      else begin
         m:=(l+r) div 2;
         if a[m].k<k then del:=del(m+1,r)
         else del:=del(l,m);
      end;
   end;
begin
   i:=del(1,n);
   if a[i].k=k then result:=a[i]
   else result.k:=nok;

end;




end.
 