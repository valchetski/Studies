unit Unit2;

interface
type
   Tinf=record
      w,c:Integer;
   end;
   mas=array [1..20] of Tinf;

   Tzad=class(Tobject)
      n,wt,ct,cmax,wmax:integer;
      s,sopt:set of byte;
      a:mas;
      procedure minw;
   end;

implementation


procedure Tzad.minw;
   function imin:integer;
   var wc,ic,i:integer;
   begin
      wc:=wmax;
      for i:=1 to n do
         if not(i in sopt) and (a[i].w<wc)then
         begin
            ic:=i;
            wc:=a[i].w;
         end;
      result:=ic;
   end;
var i,k:word;
begin
   sopt:=[];
   wt:=0;
   ct:=0;
   i:=imin;
   for k:=1 to n do
      if wt+a[i].w<wmax then
      begin
         include(sopt,i);
         wt:=wt+a[i].w;
         ct:=ct+a[i].c;
         i:=imin;
      end;
   cmax:=ct;
end;

end.
