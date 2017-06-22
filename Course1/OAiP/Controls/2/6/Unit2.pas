unit Unit2;

interface

type
   Tinf=record
      w,c:integer;
   end;
   mas=array [1..20] of Tinf;

   Tzad=class(Tobject)
      n,wt,ct,wmax,cmax:Integer;
      s,sopt:set of byte;
      a:mas;
      procedure VG(i:word;wt,oct:Integer);
   end;

implementation


procedure Tzad.VG;
var wt1,oct1:integer;
begin
   //попытка включения
   wt1:=wt+a[i].w;
   if wt1<=wmax then
   begin
      include(s,i);
      if i<n then vg(i+1,wt1,oct)
      else if oct>Cmax then
      begin
         sopt:=s;
         cmax:=oct;
      end;
      exclude(s,i);
   end;
   //попытка исключения
   oct1:=oct-a[i].c;
   if oct1>cmax then
      if i<n then vg(i+1,wt,oct1)
      else begin
         sopt:=s;
         cmax:=oct1;
      end;
end;



end.
 