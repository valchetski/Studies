%«адание 6. Ќайти область сходимости степенного р€да
syms an R n 
an = 1 / ((4 ^ (n)) * (2 * n - 1));
R = limit(abs((1/an)^(1/n)),n,inf);
fprintf('–адиус сходимости равен: %d\n', double(R));
if (R == 0)
    fprintf('ќбластью сходимости р€да €вл€етс€ одна\n единственна€ точка x = 0');    
else
    x1 = -sqrt(R) - 5; %левый конец области сходимости
    x2 = sqrt(R) - 5; %правый конец области сходимости    
    temp = symsum(an * (x1) ^ (2*n - 1), n, 1, inf);
    if (temp == inf) % провер€ем сходимость р€да в точке x1
        open_bracket = '(';
    else
        open_bracket = '[';
    end;
    temp = symsum(an * (x2) ^ (2*n - 1), n, 1, inf);
    if (temp == inf) % провер€ем сходимость р€да в точке x2
        close_bracket = ')';
    else
        close_bracket = ']';
    end;
    fprintf('ќбласть сходимости степенного р€да:  %c%d; %d%c\n', open_bracket, double(x1), double(x2), close_bracket);
end; 
%ќбласть сходимости степенного р€да: (-7; -3)