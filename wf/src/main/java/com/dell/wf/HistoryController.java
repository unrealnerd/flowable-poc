package com.dell.wf;

import java.util.List;

import org.flowable.engine.history.HistoricActivityInstance;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HistoryController {
    
    @Autowired
    WFHistoryService historyService;

    @GetMapping("/history")
    public List<HistoricActivityInstance> getActivities() {
        return historyService.getActivities();
    }

    @GetMapping("/history/servicetasks")
    public List<HistoricActivityInstance> getServiceTypeActivities() {
        return historyService.getServiceTaskActivities();
    }
}
