# Project Information
LIB2 = -r:./packages/System.Data.SQLite.Core.1.0.110.0/lib/net45/System.Data.SQLite.dll

PKG = -pkg:dotnet
PWD = $(shell pwd)
COMP = mcs
SRCPATH = ./src/
COMPILEPATH = ./dist/
FILENAME = KaffeeKasse.exe


BASEFILES = 
CONSOLE = $(SRCPATH)Program.cs

BuildConsole:
	$(COMP) $(BASEFILES) $(CONSOLE) $(LIB2) $(PKG) -out:$(FILENAME)
	mv $(FILENAME) $(COMPILEPATH)$(FILENAME)

Clean:
	rm $(COMPILEPATH)*.exe

Start:
	cd $(COMPILEPATH); \
	mono ./$(FILENAME)
