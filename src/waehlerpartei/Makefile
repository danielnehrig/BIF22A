# Project Information
LIB = -r:$(PWD)/packages/EntityFramework.6.2.0/lib/net45/EntityFramework.dll; $(PWD)/packages/System.Data.SQLite.Core.1.0.110.0/lib/net45/System.Data.SQLite.dll; $(PWD)/packages/System.Data.SQLite.EF6.1.0.110.0/lib/net45/System.Data.SQLite.EF6.dll; $(PWD)/packages/System.Data.SQLite.Linq.1.0.110.0/lib/net45/System.Data.SQLite.Linq.dll

LIB2 = -r:./packages/Mono.Data.Sqlite.1.0.61/lib/net40/Mono.Data.SQLite.dll

PKG = -pkg:dotnet
PWD = $(shell pwd)
COMP = mcs
SRCPATH = ./src/
COMPILEPATH = ./dist/
FILENAME = Politik.exe


BASEFILES = $(SRCPATH)Administration.cs $(SRCPATH)partei.cs $(SRCPATH)waehler.cs
CONSOLE = $(SRCPATH)Program.cs

BuildConsole:
	$(COMP) $(BASEFILES) $(CONSOLE) $(LIB2) $(PKG) -out:$(FILENAME)
	mv $(FILENAME) $(COMPILEPATH)$(FILENAME)

Clean:
	rm $(COMPILEPATH)*.exe
	rm $(COMPILEPATH)db.sqlite

Start:
	cd $(COMPILEPATH); \
	mono ./$(FILENAME)
