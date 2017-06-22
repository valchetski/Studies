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
  wmax,cmax: extended;
  procedure vbrminw();
 end;

implementation

procedure TPerebor.vbrminw();  //ÌÈÍÈÌÀËÜÍÛÉ ÂÅÑ
var
 i,j: word;
 t: Veschi;
 oct, tw: extended;
begin
 for i:=1 to n do
  for j:=i to n-1 do
   if a[j].w>a[j+1].w then
    begin
     t:=a[j];
     a[j]:=a[j+1];
     a[j+1]:=t;
    end;
i:=0;
oct:=0;
tw:=0;
while(i<=n) and (tw<=wmax) do
 begin
  inc(i);
  include(s,i);
  tw:=tw+a[i].w;
  oct:=oct+a[i].c;
 end;
exclude(s,i);
oct:=oct-a[i].c;
cmax:=oct;
sopt:=s;
end;

end.
