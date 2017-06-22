unit Unit2;

interface

uses
 StdCtrls, SysUtils, ComCtrls;


type
 Veschi = record
  c,w:extended;
 end;
 mas=array [1..255] of Veschi;

 TPerebor = class(TObject)
  n:byte;
  a:mas;
  s,sopt:set of byte;
  wmax,cmax,oct1:extended;
  procedure vbrvg(i:byte; tw,oct:extended);
 end;

implementation

procedure TPerebor.vbrvg;   // ¬≈“¬» » √–¿Õ»÷€
begin
if tw+a[i].w <=wmax then
 begin
  include(s,i);
  if i<n then vbrvg(i+1,tw+a[i].w,oct)
         else if oct>cmax then
          begin
           cmax:=oct;
           sopt:=s;
          end;
  exclude(s,i);
 end;
oct1:=oct-a[i].c;
if oct>cmax then if i<n then vbrvg(i+1,tw,oct1)
        else
         begin
          cmax:=oct1;
          sopt:=s;
         end;
end;


end.
