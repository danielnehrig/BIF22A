LIB = -r:../../EntityFramework.dll
PKG = -pkg:dotnet
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
	rm ./dist/server/*.exe
	rm ./dist/server/config.cfg

Start:
	cd $(COMPILEPATH); \
	mono ./$(FILENAME)
