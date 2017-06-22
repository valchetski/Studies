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
  wmax,cmax:extended;
  procedure vbrpp(i:byte; tw,oct:extended);
 end;

implementation

procedure TPerebor.vbrpp(i:byte; tw,oct:extended); // онкмши оепеанп
begin
include(s,i);
tw:=tw+a[i].w;
if i<n then vbrpp(i+1,tw,oct)
        else
         if (tw<=wmax) and (oct>cmax) then
          begin
           cmax:=oct;
           sopt:=s;
          end;
exclude(s,i);
tw:=tw-a[i].w;
oct:=oct-a[i].c;
if i<n then vbrpp(i+1,tw,oct)
        else
         if (tw<=wmax) and (oct>cmax) then
          begin
           cmax:=oct;
           sopt:=s;
          end;
end;




end.
