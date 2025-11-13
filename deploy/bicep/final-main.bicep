param location string
param environment string
param tenantId string
param objectId string

module appPlan 'appServicePlan.bicep' = {
  name: 'appPlan'
  params: {
    location: location
    planName: 'pulse360-asp-${environment}'
  }
}

module appService 'appService.bicep' = {
  name: 'appService'
  params: {
    location: location
    appName: 'pulse360-api-${environment}'
    planName: appPlan.name
  }
}

module sql 'sql.bicep' = {
  name: 'sqlModule'
  params: {
    location: location
    sqlServerName: 'pulse360-sql-${environment}'
    sqlDbName: 'pulse360db'
    administratorLogin: 'sqladmin'
    administratorPassword: 'securePassword123!' // replace with secure parameter
  }
}

module insights 'insights.bicep' = {
  name: 'insightsModule'
  params: {
    location: location
    appInsightsName: 'pulse360-insights-${environment}'
  }
}

module logs 'logAnalytics.bicep' = {
  name: 'logModule'
  params: {
    location: location
    workspaceName: 'pulse360-logs-${environment}'
  }
}

module apim 'apim.bicep' = {
  name: 'apimModule'
  params: {
    location: location
    apimName: 'pulse360-apim-${environment}'
    publisherEmail: 'admin@pulse360.com'
    publisherName: 'Pulse360'
  }
}

module acr 'acr.bicep' = {
  name: 'acrModule'
  params: {
    location: location
    acrName: 'pulse360acr${environment}'
  }
}
