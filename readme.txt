VAULT WEB VIEW


INTRODUCTION:
---------------------------------
This program creates tabs which contain an internet browser.  The URL can be set on an object-by-object basis.


REQUIREMENTS:
---------------------------------
- Vault Workgroup/Professional 2017


TO USE:
---------------------------------
Run the install and start Vault Explorer.  The Vault administrator can set the various tabs by running "Configure Web View" command in the Tools menu.  In the configure dialog, create a new view tab, set the display name of the tab, the URL value and the entity types that the tab should be used for.  See section below for how to set the URL value. So save the settings click OK.  You will be prompted to restart Vault explorer.

Now when you select an entity, you should see all the associated view tabs.  The tab contents should show the web page from the resulting URL.


SETTING THE URL:
---------------------------------
The web page in the tab is calcluated from the URL in the configuration dialog plus the Vault properties on the selected object.  When a tab is displayed anthing within {} is replaced with the property value on the selected object.  

For example, if the URL is set to "http://www.{sitename}.com" and I select an object with property sitename=autodesk, I will see the the page for "http://www.autodesk.com" in the tab view.

If you already have objects with URLs in a property value.  You can just set the URL on the tab to be "{propertyName}" where propertyName is the name of that property.


NOTES:
---------------------------------
- The resulting URL value must start with "http://".  Otherwise you won't see anything in the tab view.
- If an object is in a folder, the folder properties can also be used in the URL.  How it works is the selected object properties are applied to the URL.  Next the parent folder properties are applied to the URL.  This way if a property is not set in the selected object, the folder can provide the value.
- If there are empty property values that are required by the URL, then nothing will show up in the tab view.
- Here are some other values you can put in the URL.  When an object is selected the ## value will be replaced with the corresponding data.
	#FOLDERID# - The ID of the selected folder.
	#SERVER# - The servername.


UPDATING FROM VERSION 1.0 and 2.0
--------------------------
There is no upgrade path.  However it should be easy to set up a tab that uses the url property from prior versions.


RELEASE NOTES:
---------------------------------
22.56.4.0 - Update for Vault 2017. 
4.0.2.0 - Fixed defect where selecting a different object doesn't update web view navigation.
Fixed defect where deleting a tab in the settings dialog results in an object reference not found error.
4.0.1.0 - Update for Vault 2014.  Added support for multiple tabs.  URLs can incorporate any Vault property.
2.0.1.0 - Update for Vault 2012
1.0.2.0 - Initial Release