package com.dell.wf;

import java.util.List;

import javax.transaction.Transactional;

import org.flowable.common.engine.impl.history.HistoryLevel;
import org.flowable.engine.HistoryService;
import org.flowable.engine.ProcessEngine;
import org.flowable.engine.ProcessEngineConfiguration;
import org.flowable.engine.history.HistoricActivityInstance;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class WFHistoryService {

    ProcessEngine processEngine;

    @Autowired
    private HistoryService historyService;

    @Transactional
    public List<HistoricActivityInstance> getActivities() {

        return historyService.createHistoricActivityInstanceQuery().list();
    }

    @Transactional
    public List<HistoricActivityInstance> getServiceTaskActivities() {

        return historyService.createHistoricActivityInstanceQuery().activityType("serviceTask").list();
    }
}
