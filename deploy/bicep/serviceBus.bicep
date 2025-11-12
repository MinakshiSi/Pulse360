param location string
param namespaceName string
param topicName string

resource sbNamespace 'Microsoft.ServiceBus/namespaces@2023-01-01-preview' = {
  name: namespaceName
  location: location
  sku: {
    name: 'Standard'
    tier: 'Standard'
  }
}

resource sbTopic 'Microsoft.ServiceBus/namespaces/topics@2023-01-01-preview' = {
  name: '${namespaceName}/${topicName}'
  dependsOn: [sbNamespace]
  properties: {}
}
