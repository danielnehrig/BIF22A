LIB = -r:../../dep/EntityFramework.dll
PKG = -pkg:dotnet -pkg:gtk-sharp-2.0
COMP = mcs
SRCPATH = ./src/server/
COMPILEPATH = ./dist/server/
FILENAME = BKTMManager.exe

Build:
	cd $(SRCPATH); \
	$(COMP) -recurse:*.cs $(PKG) $(LIB) -out:$(FILENAME)
	mv $(SRCPATH)$(FILENAME) $(COMPILEPATH)$(FILENAME)
	cp $(SRCPATH)config.cfg $(COMPILEPATH)config.cfg

Clean:
	rm $(COMPILEPATH)*.exe
	rm $(COMPILEPATH)config.cfg

Start:
	cd $(COMPILEPATH); \
	mono ./$(FILENAME)
