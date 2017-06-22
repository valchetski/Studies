@echo off
:start
gsp gora -
if errorlevel 1 goto end
gsp gora0 -
if errorlevel 1 goto end
gsp gora1 -
if errorlevel 1 goto end
gsp gora2 -
if errorlevel 1 goto end
gsp gora3 -
if errorlevel 1 goto end
gsp gora4 -
if errorlevel 1 goto end
gsp gora5 -
if errorlevel 1 goto end
goto start
:end
mode co80
