# Project Information
PACKAGEPATH = ./src/server/packages/
PKG = -pkg:dotnet
COMP = mcs
SRCPATH = ./src/server/
COMPILEPATH = ./dist/server/
FILENAME = BKTMManager.exe

# Base Files
MAINSRC = $(SRCPATH)Controller/IOController.cs \
					$(SRCPATH)Administration/CategoryAdmin.cs \
					$(SRCPATH)Administration/DamagedAdmin.cs \
					$(SRCPATH)Administration/DeviceAdmin.cs \
					$(SRCPATH)Administration/HardwareAdmin.cs \
					$(SRCPATH)Administration/Manager.cs \
					$(SRCPATH)Administration/RepoAdmin.cs \
					$(SRCPATH)Administration/RoomAdmin.cs \
					$(SRCPATH)Administration/UserAdmin.cs \
					$(SRCPATH)Types/Category.cs \
					$(SRCPATH)Types/Damaged.cs \
					$(SRCPATH)Types/Device.cs \
					$(SRCPATH)Types/Reseller.cs \
					$(SRCPATH)Types/Room.cs \
					$(SRCPATH)Types/Teacher.cs \
					$(SRCPATH)Types/TypeRepo.cs \
					$(SRCPATH)Types/User.cs \
					$(SRCPATH)Types/GlobalInterface.cs \
					$(SRCPATH)Types/HardwareComponent.cs \
					$(SRCPATH)Helper/ReadConfig.cs \
					$(SRCPATH)Helper/Utils.cs

# GTK GUI Files
GTKSRC = $(SRCPATH)gtk-gui/generated.cs \
				 $(SRCPATH)gtk-gui/BKTMManager.BKTMApp.cs \
				 $(SRCPATH)gtk-gui/BKTMManager.Login.cs

# WPF GUI Files
WPFSRC = $(SRCPATH)

# Build Console GTK and WPF
CONSOLE = $(MAINSRC) $(SRCPATH)ConsoleApp/ConsoleApp.cs $(SRCPATH)Program_Console.cs
GTK = $(MAINSRC) $(GTKSRC) $(SRCPATH)Program_gtk.cs
WPF = $(MAINSRC) $(WPFSRC) $(SRCPATH)Program_wpf.cs

BuildConsole:
	$(COMP) $(CONSOLE) $(PKG) -out:$(FILENAME)
	mv $(FILENAME) $(COMPILEPATH)$(FILENAME)
	cp $(SRCPATH)config.cfg $(COMPILEPATH)config.cfg

BuildGtk:
	$(COMP) $(GTK) $(PKG) -out:$(FILENAME)
	mv $(SRCPATH)$(FILENAME) $(COMPILEPATH)$(FILENAME)
	cp $(SRCPATH)config.cfg $(COMPILEPATH)config.cfg

Clean:
	rm $(COMPILEPATH)*.exe
	rm $(COMPILEPATH)config.cfg

Start:
	cd $(COMPILEPATH); \
	mono ./$(FILENAME)
