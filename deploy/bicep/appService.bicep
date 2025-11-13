param location string
param appName string
param planName string

resource appService 'Microsoft.Web/sites@2022-03-01' = {
  name: appName
  location: location
  kind: 'app,linux'
  properties: {
    serverFarmId: resourceId('Microsoft.Web/serverfarms', planName)
    httpsOnly: true
    siteConfig: {
      linuxFxVersion: 'DOTNETCORE:8.0'
    }
  }
}
