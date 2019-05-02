# Project Information
PACKAGEPATH = ./src/server/packages/
PKG = -pkg:dotnet
COMP = mcs
SRCPATH = ./src/
COMPILEPATH = ./dist/
FILENAME = Todo.exe

CONSOLE = $(SRCPATH)Program.cs

BuildConsole:
	$(COMP) $(CONSOLE) $(PKG) -out:$(FILENAME)
	mv $(FILENAME) $(COMPILEPATH)$(FILENAME)

Clean:
	rm $(COMPILEPATH)*.exe

Start:
	cd $(COMPILEPATH); \
	mono ./$(FILENAME)
