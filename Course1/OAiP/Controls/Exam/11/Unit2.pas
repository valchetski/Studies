unit Unit2;

interface
type
Tinf = char;
TCell = ^Cell;
Cell = record
        inf:TInf;
        A:TCell;
end;

TSteck = class(TObject)
      sp,sp1:TCell;
      constructor create();
      procedure Add(inf:Tinf);
      procedure Read(var inf:Tinf);
end;

implementation

constructor TSteck.create();
begin
sp1:=nil;
end;

procedure TSteck.Add(inf:Tinf);
begin
New(sp);
sp.inf:=inf;
sp.A:=sp1;
sp1:=sp;
end;

procedure TSteck.Read(var inf:Tinf);
begin
inf:=sp1.inf;
sp:=sp1;
sp1:=sp1.A;
Dispose(sp);
end;


end.
 