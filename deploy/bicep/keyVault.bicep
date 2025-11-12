param location string = resourceGroup().location
param vaultName string
param tenantId string
param objectId string // App registration or managed identity

resource keyVault 'Microsoft.KeyVault/vaults@2023-07-01' = {
  name: vaultName
  location: location
  properties: {
    tenantId: tenantId
    sku: {
      name: 'standard'
      family: 'A'
    }
    accessPolicies: [
      {
        tenantId: tenantId
        objectId: objectId
        permissions: {
          secrets: [
            'get'
            'list'
            'set'
            'delete'
          ]
        }
      }
    ]
    enabledForDeployment: true
    enabledForTemplateDeployment: true
    enabledForDiskEncryption: false
  }
}
