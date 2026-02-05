try {
    $response = Invoke-RestMethod -Uri 'http://localhost:5175/api/leaveallocations' -Method Post -ContentType 'application/json' -Body '{"leaveTypeId": 1, "period": 2027, "employeeId": "test-emp-1"}'
    Write-Host "Success: $($response | ConvertTo-Json)"
} catch {
    Write-Host "Error: $($_.Exception.Message)"
    if ($_.Exception.Response) {
        $reader = [System.IO.StreamReader]::new($_.Exception.Response.GetResponseStream())
        Write-Host "Body: $($reader.ReadToEnd())"
    }
}
