param location string = 'southindia'
param environment string = 'dev'

module keyVault 'keyVault.bicep' = {
  name: 'kvModule'
  params: {
    location: location
    vaultName: 'credit-kv-${environment}'
  }
}

module serviceBus 'serviceBus.bicep' = {
  name: 'sbModule'
  params: {
    location: location
    namespaceName: 'credit-sb-${environment}'
    topicName: 'credit-events'
  }
}

module storage 'storage.bicep' = {
  name: 'storageModule'
  params: {
    location: location
    storageName: 'creditstorage${environment}'
  }
}
