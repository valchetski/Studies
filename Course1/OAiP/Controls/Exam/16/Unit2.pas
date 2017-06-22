unit Unit2;

interface
uses dialogs;
type
  Tinf=record
    f:shortstring;
    k:integer;
  end;
  Psel=^Tsel;
  Tsel=record
    A:Psel;
    inf:Tinf;
  end;
  Tmas=array [0..1]of Psel;
  Pmas=^Tmas;
  Thash=class(Tobject)
    sp,sp1:psel;
    m:integer;
    h:pmas;
    constructor create(m0:word);
    procedure add(inf:Tinf);
    procedure read(key:integer; var inf:Tinf);
  end;
implementation

constructor Thash.create(m0:word);
var
 i:word;
begin
 m:=m0;
 GetMem(h,m0*4);
 for i:=0 to m0-1 do h[i]:=nil;
end;

procedure Thash.add(inf:Tinf);
var
 p: PSel;
 i:word;
begin
 i:=inf.k mod m;
 New(p);
 p.inf:=inf;
 p.A:=h[i];
 h[i]:=p;
end;

procedure Thash.read(key:integer; var inf:TInf);
var
 p: PSel;
 i: word;
begin
 i:=key mod m;
 p:=h[i];
 while (p<>nil) and (p.inf.k<>key) do
  p:=p.A;
 if p<>nil then inf:=p.inf
  else showmessage('Not Found');
end;

end.

